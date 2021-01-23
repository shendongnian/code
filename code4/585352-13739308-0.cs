    public class Test
    {
        private Stopwatch watch;
        private BroadcastBlock<List<InputObject>> tempBCB;
        private BatchBlock<Tuple<List<InputObject>, Dictionary<int, IntermediateObject>>> batchBlock;
        private TransformBlock<Tuple<List<InputObject>, Dictionary<int, IntermediateObject>>[], List<FinalObject>> transformBlock;
        private ActionBlock<List<FinalObject>> justToFlushTransformBlock;
        private CoreLogic core1;
        private CoreLogic core2;
        public Test()
        {
            tempBCB = new BroadcastBlock<List<InputObject>>(input => input);
          
            //here batch size = 2
            batchBlock = new BatchBlock<Tuple<List<InputObject>,Dictionary<int,IntermediateObject>>>(2, new GroupingDataflowBlockOptions { Greedy = false });
            transformBlock = new TransformBlock<Tuple<List<InputObject>,Dictionary<int,IntermediateObject>>[],List<FinalObject>>(array =>
            {
                List<InputObject> inputObjects = array[0].Item1;
                List<FinalObject> ret = inputObjects.ConvertAll(x => new FinalObject(x));
                foreach (var tuple in array)
                {
                    //iterate over each individual object
                    foreach (var dictionary in tuple.Item2)
                    {
                        ret[dictionary.Key].outputList.Add(dictionary.Value);
                    }
                }
                return ret;
            });
            int counter = 0;
            justToFlushTransformBlock = new ActionBlock<List<FinalObject>>(list =>
                {
                    counter++;
                    Console.WriteLine("item #" + counter);
                    //just in order to accept items from the transformBlock output queue
                });
            //Generate 2 CoreLogic objects
            core1 = new CoreLogic();
            core2 = new CoreLogic();
            //linking
            tempBCB.LinkTo(core1.transformBlock, new DataflowLinkOptions { PropagateCompletion = true });
            tempBCB.LinkTo(core2.transformBlock, new DataflowLinkOptions { PropagateCompletion = true });
            core1.transformBlock.LinkTo(batchBlock);
            core2.transformBlock.LinkTo(batchBlock);
            batchBlock.LinkTo(transformBlock, new DataflowLinkOptions { PropagateCompletion = true });
            transformBlock.LinkTo(justToFlushTransformBlock, new DataflowLinkOptions { PropagateCompletion = true });
        }
        public void Start()
        {
            const int numberChunks = 30;
            watch = new Stopwatch();
            watch.Start();
            for (int j = 1; j <= numberChunks; j++)
            {
                int collectionSize = 1000 * j;
                List<InputObject> collection = new List<InputObject>(collectionSize);
                for (int i = 0; i < collectionSize; i++)
                {
                    collection.Add(new InputObject(i));
                }
                tempBCB.Post(collection);
            }
            tempBCB.Complete();
            Task.WhenAll(core1.transformBlock.Completion, core2.transformBlock.Completion).ContinueWith(_ =>
                {
                    batchBlock.Complete();
                });
            transformBlock.Completion.Wait();
            Console.WriteLine("Completed");
            Console.ReadLine();
        }
    }
    public class CoreLogic
    {
        private Random rand;
        public TransformBlock<List<InputObject>, Tuple<List<InputObject>, Dictionary<int, IntermediateObject>>> transformBlock;
        public CoreLogic()
        {
            const int numberIntermediateObjects = 1000;
            transformBlock = new TransformBlock<List<InputObject>,Tuple<List<InputObject>,Dictionary<int,IntermediateObject>>>(input =>
            {
                //please ignore the fact that `input` is not utilized here, the point is to generate a collection of IntermediateObject and return
                Dictionary<int, IntermediateObject> ret = new Dictionary<int, IntermediateObject>();
                for (int i = 0; i < numberIntermediateObjects; i++)
                {
                    IntermediateObject value = new IntermediateObject(i);
                    ret.Add(i, value);
                }
                var tuple = new Tuple<List<InputObject>, Dictionary<int, IntermediateObject>>(input, ret);
                return tuple;
            });
        }
    }
    public class InputObject : ICloneable
    {
        public int value1 { get; private set; }
        public InputObject(int value)
        {
            this.value1 = value;
        }
        object ICloneable.Clone()
        {
            return Clone();
        }
        public InputObject Clone()
        {
            return (InputObject)this.MemberwiseClone();
        }
    }
    public class IntermediateObject
    {
        public int value1 { get; private set; }
        public IntermediateObject(int value)
        {
            this.value1 = value;
        }
    }
    public class FinalObject
    {
        public InputObject input { get; private set; }
        public List<IntermediateObject> outputList;
        public FinalObject(InputObject input)
        {
            this.input = input;
            this.outputList = new List<IntermediateObject>();
        }
    }
    public static class Cloning
    {
        public static List<TValue> CloneListCloneValues<TValue>(List<TValue> original) where TValue : ICloneable
        {
            List<TValue> ret = new List<TValue>(original.Count);
            foreach (TValue entry in original)
            {
                ret.Add((TValue)entry.Clone());
            }
            return ret;
        }
    }
