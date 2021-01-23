    public enum ElementKind
    {
        RegularElement,
        IntParamElement,
        DoubleParamElement,
        LocalElement
    }
    public interface IElementFactory<TElement>
    {
        void InitElement(string name);
        void InitParam(string name, int defaultValue);
        void InitParam(string name, double defaultValue);
        void InitLocal(string name);
    }
    public class DataElement<TElement>
        where TElement : class, IElementFactory<TElement>, new()
    {
        private ElementKind FKind;
        public ElementKind Kind { get { return FKind; } }
        private string FName;
        public string Name { get { return FName; } }
        private int FDefaultInt;
        protected int DefaultInt
        {
            get { return FDefaultInt; }
            set { FDefaultInt = value; }
        }
        private double FDefaultDouble;
        protected double DefaultDouble
        {
            get { return FDefaultDouble; }
            set { FDefaultDouble = value; }
        }
        protected DataElement()
        {
        }
        public virtual void InitElement(ElementKind kind, string name)
        {
            FKind = kind;
            FName = name;
        }
        public static TElement Create(string name)
        {
            TElement obj = new TElement();
            obj.InitElement(name);
            return obj;
        }
        public static TElement CreateParam(string name, int defaultValue)
        {
            TElement obj = new TElement();
            obj.InitParam(name, defaultValue);
            return obj;
        }
        public static TElement CreateParam(string name, double defaultValue)
        {
            TElement obj = new TElement();
            obj.InitParam(name, defaultValue);
            return obj;
        }
        public static TElement CreateLocal(string name)
        {
            TElement obj = new TElement();
            obj.InitLocal(name);
            return obj;
        }
    }
    public class ByteElement : DataElement<ByteElement>, IElementFactory<ByteElement>
    {
        public ByteElement()
        {
        }
        public void InitElement(string name)
        {
            base.InitElement(ElementKind.RegularElement, name);
        }
        public void InitParam(string name, int defaultValue)
        {
            base.InitElement(ElementKind.IntParamElement, name);
            // Range checking
            if ((defaultValue >= Byte.MinValue) && (defaultValue <= Byte.MaxValue))
            {
                DefaultInt = defaultValue;
            }
        }
        public void InitParam(string name, double defaultValue)
        {
            base.InitElement(ElementKind.DoubleParamElement, name);
            // Range checking
            if ((defaultValue >= Byte.MinValue) && (defaultValue <= Byte.MaxValue))
            {
                DefaultDouble = defaultValue;
            }
        }
        public void InitLocal(string name)
        {
            base.InitElement(ElementKind.LocalElement, name);
        }
    }
