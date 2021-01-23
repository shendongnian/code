    `public class BaseClass
    {
        public string Name;
        public virtual void Write(string val)
        {
        }
    }
    public class SubClass : BaseClass
    {
        public string Address;
        public override void Write(string val)
        {
            base.Write(val);
        }
    }
