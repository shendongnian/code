    public class ComplexShape
    {
        int x;
        int y;
        int a; // large elipse width/2
        int b; // large elipse height/2
        Form1 fr;
        float angle;
        [XmlAttribute()]
        public int X { get { return x; } set { x = value; } }
        [XmlAttribute()]
        public int Y { get { return y; } set { y = value; } }
        [XmlAttribute()]
        public int A { get { return a; } set { a = value; } }
        [XmlAttribute()]
        public int B { get { return b; } set { b = value; } }
        [XmlIgnore()]
        public Form1 Form { get { return fr; } }
        [XmlAttribute()]
        public float Angle { get { return angle; } set { angle = value; } }
    }
    public class Drawing
    {
        List<ComplexShape> shapes = new List<ComplexShape>();
        [XmlIgnore()]
        public List<ComplexShape> Shapes { get { return shapes; } }
        [XmlArray("Shapes")]
        public ComplexShape[] ShapesArray
        {
            get { return shapes.ToArray(); }
            set { shapes = new List<ComplexShape>(value); }
        }
        public void Save(string fname)
        {
            XmlSerializer xml_serializer = new XmlSerializer(typeof(Drawing));
            using (Stream fstream = new FileStream(fname, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xml_serializer.Serialize(fstream, this);
                fstream.Close();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Drawing dwg = new Drawing();
            dwg.Shapes.Add(new ComplexShape());
            dwg.Shapes.Add(new ComplexShape());
            dwg.Shapes.Add(new ComplexShape());
            dwg.Shapes.Add(new ComplexShape());
            dwg.Save("ComplexShape.xml");
        }
    }
