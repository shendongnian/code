    //declare the delegate
    public delegate void MyDelegate(int aValue);
    
    public class SomeClass
    {
        public event MyDelegate MyEventFromDelegate;
        private int i;
        public int I
        {
                get
                { return i; }
                set
                {
                    if (value > 5)
                    {
                        MyEventFromDelegate(value);
                        i = 0;
                    }
                    else
                    {
                        i = value;
                    }
                }
        }
    
    }
    
    public partial class Form1 : Form
    {
        public Form1()
        {
          InitializeComponent();  
        }
    
        public void Method_To_Call(int aValue)
        {   
          MessageBox.Show("This method signals that value is greater than 5. Value=" + aValue.ToString());
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            SomeClass a = new SomeClass();
            a.MyEventFromDelegate +=new MyDelegate(Method_To_Call);
            a.I = 12;
        }
    }
