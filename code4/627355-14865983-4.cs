    public abstract class Module
    {
        internal int ID;
        public abstract void ModuleStart();
        protected void function1()
        {
            System.Console.WriteLine ("function1 called from module {0}", this.ID);
        }
    }
