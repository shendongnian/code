    public abstract class SKConsoleParameter
    {
        protected string value;
        public SKConsoleParameter(string value)
        {
            this.value = value;
        }
        public string GetRawValue()
        {
            return value;
        }
        public abstract bool IsValid();
        public abstract object GetValue();
    }
    public class StringParam : SKConsoleParameter
    {
        public StringParam(string value) : base(value) { }
        public override bool IsValid()
        {
            return true;
        }
        public override object GetValue()
        {
            return value;
        }
    }
    public class IntParam : SKConsoleParameter
    {
        public IntParam(string value) : base(value) { }
        public override bool IsValid()
        {
            int i;
            return int.TryParse(value, out i);
        }
        public override object GetValue()
        {
            int i;
            if (int.TryParse(value, out i))
                return i;
            else
                return 0;
        }
    }   
    class Program
    {
        public delegate void CoolDelegate(params SKConsoleParameter[] parameters);
        static void Main(string[] args)
        {
            var s = new StringParam("Glenn");
            var i = new IntParam("12");
            var coolDel = new CoolDelegate(DoSomethingCool);
            coolDel(s, i);
        }
        public static void DoSomethingCool(params SKConsoleParameter[] parameters)
        {
            if (parameters == null) throw new ArgumentNullException("parameters");
            foreach (var item in parameters)
            {
                if (item is IntParam)
                {
                    // do something interesting
                    continue;
                }
                if (item is StringParam)
                {
                    // do something else interesting
                    continue;
                }
                throw new NotImplementedException("unknown param type");
            }
        }
    }
