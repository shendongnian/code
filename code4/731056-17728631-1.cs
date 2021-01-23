    public class Program
    {
        public static void Main(string[] args)
        {
            Test test = new Test();
            test.MethodName(1);
        }
    }
    public class Test
    {
        private string variable1 = "1";
        private string variable2 = "2";
        public void MethodName(int variablenum)
        {
            // .Instance because not static, .NonPublic because private
            const BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
            FieldInfo field = GetType().GetField("variable" + variablenum, flags);
            string s = (string)field.GetValue(this);          
        }
    }
