    public class MyClass
    {
        public string[] GetMyData(string fileName)
        {
            string[] data = GetDataFromFile(fileName);
            return data;
        }
    
        protected virtual string[] GetDataFromFile(string fileName)
        {
            return FileUtil.ReadDataFromFile(fileName);
        }
    }
