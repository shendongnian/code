    public class GenericA : Generic {
        DataClass dataA { get { return data; } set { data = value; } }
    }
    public class GenericB : Generic {
        DataClass dataB { get { return data; } set { data = value; } }
    }
    Generic a = JsonConvert.DeserializeObject<GenericA>("JSON using dataA");
    Generic b = JsonConvert.DeserializeObject<GenericB>("JSON using dataB");
