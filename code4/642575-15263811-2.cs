    [ComVisible(true)]
    [Guid("2EF06BCB-A25B-41AD-B233-33A956DBEB69")]
    public struct Ponto
    {
        public double x;
        public double y;
        public Ponto(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
    [ComVisible(true)]
    [Guid("EB9258F5-DCFB-4F91-8342-5A05EB17557D")]
    public interface IManagedClass
    {
        Ponto[] Foo();
    }
    [ComVisible(true)]
    [Guid("11B23AD7-F79E-45D7-BC87-89F0DBC8B83F")]
    [ClassInterface(ClassInterfaceType.None)]
    public class ManagedClass : IManagedClass
    {
        private List<Ponto> points;
        public ManagedClass()
        {
            points = new List<Ponto>();
            points.Add(new Ponto(1.0, 1.0));
            points.Add(new Ponto(2.0, 2.0));
            points.Add(new Ponto(3.0, 3.0));
        }
        public Ponto[] Foo()
        {
            return points.ToArray();
        }
    }
