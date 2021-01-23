    public class MyObject {
        private string _name;
        private int _age;
        private string _tooltip;
        public string Name {
            get { return _name; }
            set { _name = value; }
        }
        [Browsable(false)]
        public string Tooltip {
            get { return _tooltip; }
            set { _tooltip = value; }
        }
        public int Age {
            get { return _age; }
            set { _age = value; }
        }
    }
    private void Form1_Load(object sender, EventArgs e) {
       List<MyObject> list = new List<MyObject>();
       list.Add(new MyObject 
                { Name = "my name", Tooltip="tooltip1", Age = 18 });
       list.Add(new MyObject 
                { Name = "just my other name", Tooltip="tooltip2", Age = 18});                                    
       this.dataGridView1.DataSource = list;
    }
    private void dataGridView1_CellToolTipTextNeeded(object sender, 
      DataGridViewCellToolTipTextNeededEventArgs e)   {
      if ((e.RowIndex > -1) && (e.ColumnIndex == this.dataGridView1.Columns["Name"].Index)) {
        e.ToolTipText = 
               ((MyObject)(dataGridView1.Rows[e.RowIndex].DataBoundItem)).Tooltip;
      }
    }
