    [Serializable]
    class customSampleData  : ISerializable, IDeserializationCallback
    {
        public string FName
        {
            get;
            private set;
        }
        public string MName
        {
            get;
            private set;
        }
        public string LName
        {
            get;
            private set;
        }
        public string Age
        {
            get;
            private set;
        }
        public string Address
        {
            get;
            private set;
        }
        public string Religion
        {
            get;
            private set;
        }
        public DateTime BDay
        {
            get;
            private set;
        }
        public string Sex
        {
            get;
            private set;
        }
        public string CStatus
        {
            get;
            private set;
        }
        public customSampleData (string pFName, string pMName, string pLName, string pAge, string pAddress, string pReligion, DateTime pBDay, string pSex, string pCStatus)
        {
            FName = pFName;
            MName = pMName;
            LName = pLName;
            Age = pAge;
            Address = pAddress;
            Religion =pReligion;
            BDay =pBDay;
            Sex = pSex;
            CStatus = pCStatus;
        }
        public customSampleData(SerializationInfo info, StreamingContext context)
        {
            // Deserialization Constructor 
            FName = info.GetString("FName");
            MName = info.GetString("MName");
            LName = info.GetString("LName");
            Age = info.GetString("Age");
            Address = info.GetString("Address");
            Religion = info.GetString("Religion");
            BDay = Convert.ToDateTime(info.GetString("BDay"));
            Sex = info.GetString("Sex");
            CStatus = info.GetString("CStatus");
            Console.WriteLine("Deserializing constructor");
        }
        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            Console.WriteLine("OnSerializing fired.");
        }
        [OnSerialized]
        private void OnSerialized(StreamingContext context)
        {
            Console.WriteLine("OnSerialized fired.");
        }
        [OnDeserializing]
        private void OnDeserializing(StreamingContext context)
        {
            Console.WriteLine("OnDeserializing fired.");
        }
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            Console.WriteLine("OnDeserialized fired.");
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Console.WriteLine("Serializing...");
            info.AddValue("FName", FName);
            info.AddValue("MName", MName);
            info.AddValue("LName", LName);
            info.AddValue("Age", Age);
            info.AddValue("Address", Address);
            info.AddValue("Religion", Religion);
            info.AddValue("BDay", BDay);
            info.AddValue("Sex", Sex);
            info.AddValue("CStatus", CStatus);
        }
        void IDeserializationCallback.OnDeserialization(object sender)
        {
            Console.WriteLine("IDeserializationCallback.OnDeserialization method.");
        }
    }
       customSampleData tc = new customSampleData("fname", "mname", "pLName", "pAge", "pAddress", "pReligion", DateTime.Now, "pSex", "pCStatus");
            FileStream fs = new FileStream("Serialized.txt", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, tc);
            fs.Close();
            tc = null;
            fs = new FileStream("Serialized.txt", FileMode.Open);
            tc = (customSampleData)bf.Deserialize(fs);
            Console.WriteLine("fname = " + tc.FName);
