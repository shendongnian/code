    public class Tester 
    {
        public Tester()
        {
            this.TestSerialization();
            
        }
        public void SerializeToFile(RecoveryMethodData recoveryMetaData,string fileName)
        {
            var encoding = Encoding.UTF8;
            using (var fileWriter = new XmlTextWriter(fileName, encoding))
            {
                fileWriter.Formatting = Formatting.Indented;
                // use SharedTypeResolver for deserializing assistance.
                var serializer = new DataContractSerializer(typeof(RecoveryMethodData),new List<Type>(){typeof(bool),typeof(Result),typeof(List<Result>)});                
                serializer.WriteObject(fileWriter,recoveryMetaData);
            }
        }
        private void TestSerialization()
        {
            var methodData = new RecoveryMethodData();
            var result = new Result() { Message = "wow", Pass = true, FileName = "somefile " };
            methodData.Add(result);
            methodData.Add(true);
            var list1 = new List<Result>();
            list1.Add(new Result() { FileName = "in list1", Message = "in l 1" });
            list1.Add(new Result() { FileName = "in list2", Message = "in l 2" });
            methodData.Add(list1);
            SerializeToFile(methodData, @"C:\serialization_result.xml");
        }
    }
    public class Result
    {
        public string Message { get; set; }
        public string FileName { get; set; }
        public bool Pass { get; set; }
    }
    
    public class RecoveryMethodData : List<object>
    {
        
    }
