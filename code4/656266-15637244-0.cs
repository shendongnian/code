    static class Program
    {
        static void Main()
        {
            var method = typeof(Program).GetMethod("Test");
    
            Describe(method.ReturnParameter);
            foreach (var p in method.GetParameters()) Describe(p);
        }
        static void Describe(ParameterInfo param)
        {
            Console.WriteLine("{0}, {1}, {2}",
                string.IsNullOrEmpty(param.Name) ? "(no name)" : param.Name,
                param.ParameterType, param.Position);
            if (param.IsRetval) Console.WriteLine("retval");
            if (param.IsIn) Console.WriteLine("in");
            if (param.IsOut) Console.WriteLine("out");
            if (param.ParameterType.IsByRef) Console.WriteLine("by-ref");
            if (param.IsOptional) Console.WriteLine("optional");
            if (param.HasDefaultValue)
            {
                Console.WriteLine("default value: {0}", param.DefaultValue);
            }
            Console.WriteLine();
        }
        public static int Test(int j, ref int k, out int l, string foo = "abc")
        {
            throw new NotImplementedException();
        }
    }
