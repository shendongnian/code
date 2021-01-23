    class Program
    {
        static void Main(string[] args)
        {
            List<string> p2 = new List<string>();
            string p3;
            string p4 = "input string";
            string result = MethodCaller(typeof(DateTime), ref p2, out p3, p4);
        }
        public static string MethodCaller(Type theType, ref List<string> p2, out string p3, string p4)
        {
            MethodInfo method = (from m in typeof(Example).GetMethods()
                                 let p = m.GetParameters()
                                 where m.Name == "Method"
                                 && p.Length == 3
                                 && p[0].ParameterType.IsByRef
                                 && p[0].ParameterType.HasElementType
                                 && p[0].ParameterType.GetElementType() == typeof(List<string>)
                                 && p[1].ParameterType.IsByRef
                                 && p[1].ParameterType.HasElementType
                                 && p[1].ParameterType.GetElementType() == typeof(string)
                                 && p[2].ParameterType == typeof(string)
                                 select m).Single();
            MethodInfo genericMethod = method.MakeGenericMethod(theType);
            object[] parameters = new object[] { null, null, p4 };
            string returnValue = (string)genericMethod.Invoke(null, parameters);
            p2 = (List<string>)parameters[0];
            p3 = (string)parameters[1];
            return returnValue;
        }
    }
    static class Example
    {
        public static string Method<T>(ref List<string> p2, out string p3, string p4)
        {
            p2 = new List<string>();
            p2.Add(typeof(T).FullName);
            p2.Add(p4);
            p3 = "output string";
            return "return value";
        }
        public static string Method<T>(ref List<string> p2, out string p3, int p4)
        {
            p2 = new List<string>();
            p2.Add(typeof(T).FullName);
            p2.Add(p4.ToString());
            p3 = "output string";
            return "return value";
        }
    }
