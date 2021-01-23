    public class Foo
    {
        public int Id;
        public string RawData;
        private object thisObject;
        public object ThisObject 
        {
            get
            {
                return thisObject ?? (thisObject = JsonConvert.DeserializeObject<object>(RawData));
            }
        }        
    }
