    public class ClassA
    {
        public IDictionary<string, DataSet> DataDic { get; private set; }
    
        public ClassA()
        {
            DataDic = new Dictionary<string, DataSet>();
            DataDic.Add("Key1",".......");
            // ...
        }
    }
