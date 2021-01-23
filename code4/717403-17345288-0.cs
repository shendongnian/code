    public interface IObject
    {
        bool HitTest(Point mouseLocation);
        void Paint(Graphics g);
        List<IAdorner> Adorners { get; }
    }
    public interface IAdorner
    {
        bool HitTest(Point mouseLocation);
        void Paint(Graphics g);
    }
