    doWhatever(Fn); 
//////
   
    public delegate void ToDO();
    class Program
    {
        public void Fn()
        {
            Console.WriteLine("This is Fn");
        }
        public void doWhatever(ToDO t)
        {
            methodToPrepareEnvironment();
            t();
            methodToResumeEnvironment();
        }
    }
