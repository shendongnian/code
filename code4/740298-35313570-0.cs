    private void Form1_Load(object sender, EventArgs e)
    {
        List<Person> list = new List<Person>();
        list.Add(new Person(20, true));
        list.Add(new Person(25, false));
        list.Add(new Person(30, true));
    
        dgv.DataSource = list;
    
        //Hide checkbox column
        dgv.Columns["IsProgrammer"].Visible = false;
    
        //Add represent text column
        DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
        textColumn.Name = "Yes / No";
        dgv.Columns.Add(textColumn);
    
        //true/false -> yes/no
        foreach (var row in dgv.Rows.Cast<DataGridViewRow>())
            row.Cells["Yes / No"].Value = (bool)row.Cells["IsProgrammer"].Value ? "Yes" : "No";
    }
    private class Person
    {
        public int Age { get; set; }
        public bool IsProgrammer { get; set; }
    
        public Person(int i, bool b)
        {
            Age = i;
            IsProgrammer = b;
        }
    }
