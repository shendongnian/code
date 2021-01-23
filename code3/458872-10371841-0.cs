    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ChildClass child = new ChildClass();
            Text = ParentClass.mymethod(child);
        }
    }
    
    class ParentClass
    {
        public virtual string s { get { return "parent string"; }  }
    
        public static string mymethod(ParentClass parent)
        {
            return parent.s;
        }
    }
    
    class ChildClass : ParentClass
    {
        public override string s { get { return "child string"; }  }
    }
