    class Program
    {
        static void Main(string[] args)
        {
            myClass currentObj = new myClass() { Text = "test", Value = 5 };
            myClass updatedObj = new myClass() { Text = "test 2 ", Value = 6 };
            Type cType = currentObj.GetType();
            var fieldInfos = cType.GetFields();
            foreach (var fieldInfo in fieldInfos)
            {
                if (fieldInfo.GetValue(updatedObj) != null)
                {
                    fieldInfo.SetValue(currentObj, fieldInfo.GetValue(updatedObj));
                }
            }
        }
    }
    class myClass
    {
        public string Text;
        public int Value;
    }
