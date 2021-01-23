    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
    
            Class1 c1 = new Class1() { i = 1, j = 2 };
            Class1 c2 = Duplicate(c1);
            c1.i = 3;
            Text = c2.i.ToString();//Prints "1";
        }
    
        public Class1 Duplicate(Class1 c)//Duplicates all public properties.
        {
            Class1 result = new Class1();
            PropertyInfo[] infos = typeof(Class1).GetProperties();
            foreach (PropertyInfo info in infos)
                info.SetValue(result, info.GetValue(c, null), null);
            return result;
        }
    }
    
    public class Class1
    {
        public int i { get; set; }
        public int j { get; set; }
    }
