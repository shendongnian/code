    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private List<string> lista = new List<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Before:");
            foreach (string value in lista)
            {
                Console.WriteLine(value);
            }
            for (char i = 'a'; i < 'z'; i++)  
            {  
                string name = "list" + i;
                System.Reflection.FieldInfo fi = this.GetType().GetField(name, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);
                if (fi != null && fi.FieldType.Equals(typeof(List<string>)))
                {
                    List<string> referenceToList = (List<string>)fi.GetValue(this);
                    referenceToList.Add("Hello!");
                }
            }
            Console.WriteLine("After:");
            foreach (string value in lista)
            {
                Console.WriteLine(value);
            }
        }
    }
