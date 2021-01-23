    public interface IData
    {
        Color color {get;set;}
        int len {get;set;}
        DrawingVisual dv {get;set;}
    }
    public interface Data1
    {
        public Color color {get;set;}
        public int len {get;set;}
        public DrawingVisual dv {get;set;}
    }
    public interface Data2
    {
        public Color color {get;set;}
        public int len {get;set;}
        public DrawingVisual dv {get;set;}
    }
    void Something(IData data)
    {
       // use the properties defined in the IData interface
    }
    Something(new Data1());
    Something(new Data2());
