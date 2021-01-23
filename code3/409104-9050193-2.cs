    public partial class Form1 : Form
    {
        class MyClass
        {
            public bool Check { get; set; }
            public string Name { get; set; }
        }
        public Form1()
        {
            InitializeComponent();
            List<MyClass> lst = new List<MyClass>();
            lst.AddRange(new[] { new MyClass { Check = false, Name = "item 1" }, new MyClass { Check = false, Name = "item 2" } });
            dataGridView1.DataSource = lst;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (dataGridView1.IsCurrentCellDirty)
                    dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                if (dataGridView1.CurrentCell.Value.ToString().Equals("True"))
                {
                    MessageBox.Show("Now do the job while checked value changed to True.");
                    //
                    // Do the job here.
                    //
                }
            }
        }
    }
