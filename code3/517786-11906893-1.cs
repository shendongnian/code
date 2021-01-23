    public class SomeCoolClass
    {
        public string Summary = "I'm telling you";
        public void DoSomeMethod()
        {
            string myInterval = this.Summary + " this is what happened!";
        }
        public static void DoSomeOtherMethod(SomeCoolClass instance)
        {
            string myInterval = instance.Summary + " it didn't happen!";
        }
    }
