    public enum ElementSize
    {
        Small,
        Big
    }
    public enum ElementColor
    {
        Green,
        Red,
        Blue
    }
    public enum Temperature
    {
        Hot,
        Cold
    }
    public class Element<T>
    {
        public T Value { get; set; }
        public ElementColor Color { get; set; }
        public Temperature Temperature { get; set; }
        public ElementSize Size { get; set; }
    }
    public class Data<T>
    {
        private readonly IList<Element<T>> list = new List<Element<T>>();
        public T Value
        {
            get
            {
                if ( list.Count == 1 )
                    return list[0].Value;
                else
                    throw new Exception("Throw a proper exception or consider not implementing this property at all");
            }
        }
        public Data<T> Green
        {
            get { return FilterByColor(ElementColor.Green); }
        }
        public Data<T> Red
        {
            get { return FilterByColor(ElementColor.Red); }
        }
        private Data<T> FilterByColor(ElementColor color)
        {
            return new Data<T>(from x in list where x.Color == color select x);
        }
        //etc...
        public Data<T> Small
        {
            get { return new Data<T>(from x in list where x.Size == ElementSize.Small select x); }
        }
        public Data<T> Cold
        {
            get { return new Data<T>(from x in list where x.Temperature == Temperature.Cold select x); }
        }
        public void Add(Element<T> element)
        {
            list.Add(element);
        }
        public Data(IEnumerable<Element<T>> list)
        {
            this.list = new List<Element<T>>(list);
        }
    }
