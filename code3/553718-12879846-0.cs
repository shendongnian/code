    public class MyDic : Dictionary<String, String>
    {
        public string LastKey { get; set; }
    
        public String this[String key]
        {
            get
            {
                LastKey = key;
                return this.First(x => x.Key == key).Value;
            }
            set
            {
                LastKey = key;
                base[key] = value; // if you use this[key] = value; it will enter an infinite loop and cause stackoverflow
            }
        }
