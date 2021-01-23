    public class GenericA : Generic {
        public DataClass dataA { get { return data; } set { data = value; } }
    }
    public class GenericB : Generic {
        public DataClass dataB { get { return data; } set { data = value; } }
    }
    Generic a = JsonConvert.DeserializeObject<GenericA>("JSON using dataA");
    Generic b = JsonConvert.DeserializeObject<GenericB>("JSON using dataB");
