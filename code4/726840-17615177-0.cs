    public partial class MyForm : Form
    {
        List<MyData> data = new List<MyData>();
        BindingSource bs = new BindingSource();
    
        public MyForm()
        {
            IntializeComponents();
            bs.DataSource = data;
    
           listBox1.DisplayMember = "Name";
           listBox1.ValueMember = "Id";
           listBox1.DataSource = bs;
        }
    
        private void buttonAddData_Click(object sender, EventArgs e)
        {
           var selection = (MyData)comboBox1.SelectedItem;
           data.Add(selection);
           
           bs.ResetBindings(false);
        }
    }
