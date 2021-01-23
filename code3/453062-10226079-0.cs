    public class forInherit
    {
        public virtual int getUserID()
        {
            return 0;
        }
    }
    
    public class logFunctions : forInherit
    {
        public Func<int> GetUserIDDelegate { get; set; }
    
        public override int getUserID()
        {
            if(GetUserIDDelegate == null)
                return 0;
            return GetUserIDDelegate();
        }
    }
