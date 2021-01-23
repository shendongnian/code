    class Base
    {
        public void InvokeMethodWithSetup(string method, Database db, params object[] args)
        {
            PerformSetup(db);
            var method = this.GetType().GetMethod(method);
            method.Invoke(this, args);   
        }
        
        public void PerformSetup(Database db)
        {
            // stuff
        }
    }
