    public class Signature{
        string property1;
        string property2;
        public Signature(string propertyVal1, string propertyVal2)
        {
            property1 = propertyVal1;
            property2 = propertyVal2;
        }
    }
        Signature[] mySignatures = new Signature[3];
    
        public Form1()
        {
            InitializeComponent();
            mySignatures[0] = new Signature("hello", "world");
            mySignatures[1] = new Signature("hello", "world");
            mySignatures[2] = new Signature("hello", "world");
            for (int i = 0; i < mySignatures.Length; i++)
            {
                comboBox1.Items.Add(mySignatures[i]);
            }
        }
