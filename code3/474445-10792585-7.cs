    public partial class Form2 : Form
    {
        public delegate void SaveEventHandler(object sender, SaveEventArgs e);
        public event SaveEventHandler SaveEvent;
        public string name { get; set; }
        public string age { get; set; }
        public Form2()
        {
            InitializeComponent();
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = name;
            textBox2.Text = age;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SaveEvent(this, new SaveEventArgs(textBox1.Text, textBox2.Text));
        }
    }
    public class SaveEventArgs
    {
        public SaveEventArgs(string name, string age) {newName = name; newAge = age; }
        public String newName {get; private set;} // readonly
        public String newAge {get; private set;}
    }
