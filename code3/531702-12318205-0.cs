    public class State
    {
        public int input { get; set; }
        public int result { get; set; }
        //public static int ThreadCount { get; set; }
        public bool FuncBSignalON { get; set; }
        //public static bool FuncAThreadON { get; set; }
       //public int TotalLoopCount { get; set; }
        //public int ThreadID { get; set; }
    }
    public class MainClass
    {
        public static void FuncB(Object stateObject)
        {
            State state = stateObject as State;
            state.input += 2;
            state.FuncBSignalON = true;
            ThreadPool.QueueUserWorkItem(new WaitCallback(FuncA), state);
        }
        public static void FuncA(Object stateObject)
        {
            State state = (State)stateObject;
            if (!state.FuncBSignalON)
            {
                state.input += 1;
                ThreadPool.QueueUserWorkItem(new WaitCallback(FuncB), state);
            }
            else
            {
                state.result = state.input + 3;
                //FinalResult.Add(state.result);
                string[] stateResult = new string[1];
                stateResult[0] = state.result.ToString();
                //State.ThreadCount--;
                Main(stateResult);
            }
        }
        static void Main(string[] args)
        {
            if (args.Count() == 0)
            {
                int TotalLoopCount =1000; 
                for (int i = 0; i < TotalLoopCount; i++)
                {
                    State FuncAstate = new State();
                    FuncAstate.input = 11;
                    //FuncAstate.TotalLoopCount = TotalLoopCount;
                    //State.ThreadCount++;
                    ThreadPool.QueueUserWorkItem(new WaitCallback(FuncA), FuncAstate);
                }
            }
            else
            {
              Console.WriteLine(args[0]);
            }
            Console.ReadKey();
        }
    }
