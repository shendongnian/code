    public class Demo {
        public static string ThisIsGlobal = "Global";
        private string _field = "this is a field in the class";
        public void DoSomething()
        {
            string localVariable = "Local";
            string localVariable2 = ThisIsGlobal; // VALID
        }
        public static void GlobalMethod()
        {
            string localVariable = _field; // THIS IS NOT VALID!
        }
    }
