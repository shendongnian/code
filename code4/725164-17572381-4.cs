    class Program
    {
        static void Main()
        {
            var list = new List<int>();
            for (int i = 0; i < int.MaxValue / 100; i++)
            {
                list.Add(i);
            }
            TimeItAccurate(ListCopy_1, list, 10);
            TimeItAccurate(ListCopy_2, list, 10);
            TimeItAccurate(ListCopy_3, list, 10);
            TimeItAccurate(ListCopy_4, list, 10);
        }
        private static List<int> ListCopy_1(List<int> list)
        {
            var newList = list.ToList();
            return newList;
        }
        private static List<int> ListCopy_2(List<int> list)
        {
            var newList = new List<int>(list.Count);
            foreach (var i in list)
            {
                newList.Add(i);
            }
            return newList;
        }
        private static List<int> ListCopy_3(List<int> list)
        {
            var newList = new List<int>(list.ToArray());
            return newList;
        }
        private static List<int> ListCopy_4(List<int> list)
        {
            var newList = new List<int>(list.Count);
            newList.AddRange(list);
            return newList;
        }
        private static List<int> ListCopy_5(List<int> list)
        {
            var newList = new List<int>(list);
            return newList;
        }
        public static void TimeItAccurate<TIn, TResult>(Func<TIn, TResult> func, TIn argument, int iterationsCount)
        {
            #region Pre-heat
            for (int i = 0; i < 10; i++)
            {
                var t = func.Invoke(argument);
            }
            #endregion
            var stopwatch = new Stopwatch();
            var result = default(TResult);
            stopwatch.Start();
            for (int i = 0; i < iterationsCount; i++)
            {
                result = func.Invoke(argument);
            }
            stopwatch.Stop();
            Console.WriteLine("Result:\n{4}(...) == {0}\n\n{1} iterations done in {2} ms.\nAverage time: {3:f5} ms.",
                result,
                iterationsCount,
                stopwatch.ElapsedMilliseconds,
                stopwatch.ElapsedMilliseconds / (double)iterationsCount,
                func.Method.Name);
        }
    }
