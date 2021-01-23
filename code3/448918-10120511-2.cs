    using System.Reflection;
    public class MyClass
    {
        public static string x = "1";
        public static int y = 2;
        public static bool TryGetValue<T>(string variableName, out T value)
        {
            try
            {
                var myType = typeof(MyClass);
                var fieldInfo = myType.GetField(variableName);
                value = (T)fieldInfo.GetValue(myType);
                return true;
            }
            catch
            {
                value = default(T);
                return false;
            }
        }
    }
