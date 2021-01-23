    public delegate void ListViewAddDelegate(string text);
    
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            public void AddItem(string item)
            {
                listView1.Items.Add(item);
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                ListViewAddDelegate Del = new ListViewAddDelegate(AddItem);
                Form2 ob = new Form2(Del);
                ob.Show();
            }
        }
    
       
    }
