    public class MainClass
    {
        public static List<int> finalResult = new List<int>();
        public static void FuncB(Object stateObject)
        {
                State state = stateObject as State;
                state.result += 2;
                MainClass.finalResult.Add(state.result);
                State.ThreadCount--;
        }
        public static void FuncA(Object stateObject)
        {
            State state = (State)stateObject;
            state.input += 1;
            State.ThreadCount++;
            ThreadPool.QueueUserWorkItem(new WaitCallback(FuncB), state);
            state.result = state.input + 3;
        }
        static void Main()
        {
            int TotalLoopCount = 1000;
            for (int i = 0; i < TotalLoopCount; i++)
            {
                State FuncAstate = new State();
                FuncAstate.input = 11;
                FuncA(FuncAstate);
            }
            while (State.ThreadCount > 0)
            {
                Console.WriteLine("Waiting for all the threads to terminate. Still {0} no of threads available in memory", State.ThreadCount);
                State.ThreadCount--;
                continue;
            }
           
           for (int i = 0; i < MainClass.finalResult.Count(); i++)
           {
                  Console.WriteLine("The final Result {0}", MainClass.finalResult[i]);
            }
            Console.ReadKey();
        }
