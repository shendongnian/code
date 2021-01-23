    public class myProgram
    {
        public static IEnumerable<string> Something
        {
            get
            {
                string var = MethodBase.GetCurrentMethod().Name;
                return GetSomethingInternal();
            }
        }
        private static IEnumerable<string> GetSomethingInternal()
        {
            for (int i = 0; i < 5; i++)
            {
                yield return i;
            }
        }
    }
