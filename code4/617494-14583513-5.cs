    public class abc
    {
        public int i = 0;
        public string a = "";
    
        public abc Clone(abc instanceToClone)
        {
            abc result = new abc();
            result.i = instanceToClone.i;
            result.a = instanceToClone.a;
        }
    }
