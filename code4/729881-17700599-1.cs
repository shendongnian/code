    class Program
    {
        static void Main(string[] args)
        {
            string str = "a=1,b=2,c=3,d=\"4=four\"";
            string script = String.Format("new {{ {0} }}",str);
            var engine = new ScriptEngine();
            dynamic d = engine.CreateSession().Execute(script);
        }
    }
