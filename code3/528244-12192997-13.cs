    [TestClass]
      public class ParallelShuffle
      {
        private int nSwap = 0;
        private int nConflict = 0;
        [TestMethod]
        public void Test()
        {
          const int size = 100000;
          const int thCount = 8;
          var sentinel = new object();
          var array = new object[size];
    
          for(int i = 0; i < array.Length; i++)
            array[i] = i;
    
          for(var nRun = 0; nRun < 10; ++nRun) {
            nConflict = 0;
            nSwap = 0;
            var sw = Stopwatch.StartNew();
            var tasks = new Task[thCount];
            for(int i = 0; i < thCount; ++i) {
              tasks[i] = Task.Factory.StartNew(() => {
                var rand = new Random();
                var spinWait = new SpinWait();
                for(var count = array.Length - 1; count > 1; count--) {
                  var y = rand.Next(count);
                  OptimisticalSwap(array, count, y, sentinel, spinWait);
                }
              }, CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            }
    
            Task.WaitAll(tasks);
    
            //Console.WriteLine(String.Join(", ", array));
            Console.WriteLine("Run {3} took {0}ms (nSwap={1}, nConflict={2})", sw.ElapsedMilliseconds, nSwap, nConflict, nRun);
            // check for doubles:
            var checkArray = new bool[size];
            for(var i = 0; i < array.Length; ++i) {
              var value = (int) array[i];
              Assert.IsFalse(checkArray[value], "A double! (at {0} = {1})", i, value);
              checkArray[value] = true;
            }
          }
        }
    
       private void OptimisticalSwap(object[] arr, int i, int j, object sentinel, SpinWait spinWait)
        {
          Interlocked.Increment(ref nSwap);
          if(i == j) return;
          var vi = ExchangeWithSentinel(arr, i, sentinel, spinWait);
          var vj = ExchangeWithSentinel(arr, j, sentinel, spinWait);
          Interlocked.Exchange(ref arr[i], vj);
          Interlocked.Exchange(ref arr[j], vi);
        }
    
        private object ExchangeWithSentinel(object[] arr, int i, object sentinel, SpinWait spinWait)
        {
          spinWait.Reset();
          while(true) {
            var vi = Interlocked.Exchange(ref arr[i], sentinel);
            if(vi != sentinel) return vi;
            spinWait.SpinOnce();
          }
        }
