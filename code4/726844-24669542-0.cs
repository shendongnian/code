    public partial class MyForm : Form
    {
        ObservableCollection<MyData> data = new ObservableCollection<MyData>();
        public MyForm()
        {
            listBox1.DataSource = data;
            listBox1.DisplayMember = "Name";
            listBox1.ValueMember = "Id";
        }
    
        private void buttonAddData_Click(object sender, EventArgs e)
        {
           var selection = (MyData)comboBox1.SelectedItem;
           data.Add(selection);
        }
    }
