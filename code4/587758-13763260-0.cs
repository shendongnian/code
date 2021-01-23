     public partial class Form1 : Form
    {
        class MyClass
        {
            public MyClass(string name, int id)
            {
                Name = name;
                Id = id;
            }
            public string Name { get; set; }
            public int Id { get; set; }
        }
        List<MyClass> dsList = new List<MyClass>();
        public Form1()
        {
            
            for (int i = 0; i < 10; i++)
            {
                dsList.Add(new MyClass("Name" + i , i));
            }
            InitializeComponent();
            comboBox1.DataSource = dsList;
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Checks if item with the typed Id exists in the DataSource
            // and selects it if it's true
            int typedId = Convert.ToInt32(textBox1.Text);
            bool exist = dsList.Exists(obj => obj.Id == typedId);
            if (exist) comboBox1.SelectedValue = typedId;
            
        }
      
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            MyClass obj = comboBox1.SelectedValue as MyClass;
            if (obj != null) textBox1.Text = obj.Id.ToString();
        }
    }
