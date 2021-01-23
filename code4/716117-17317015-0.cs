    public partial class Form1 : Form
    {
        BindingSource bs = new BindingSource();
        BindingList<myObj> myObjList = new BindingList<myObj>();
        public Form1()
        {
            InitializeComponent();
            
            myObjList.Add(new myObj("LastNameA", "Peter"));
            myObjList.Add(new myObj("LastNameA", "Klaus"));
            myObjList.Add(new myObj("LastNameB", "Peter"));
            bs.DataSource = myObjList;
            dataGridView1.DataSource = myObjList;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BindingList<myObj> filtered = new BindingList<myObj>(myObjList.Where(obj => obj.Name.Contains(textBox1.Text)).ToList());
            dataGridView1.DataSource = filtered;
            dataGridView1.Update();
        }
    }
    public class myObj
    {
        public myObj(string LastName, String Name)
        {
            this.LastName = LastName;
            this.Name = Name;
        }
        public string LastName { get; set; }
        public string Name { get; set; }
    }
}
