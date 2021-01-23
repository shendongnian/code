    class Stuff
        {
            public string Name { get; set; }
            public string CieName { get; set; }
    
            public override string ToString()
            {
                return string.Format("{0}-{1}", Name, CieName);
            }
        }
    
        public partial class Form1 : Form
        {
            private List<Stuff> _myList = new List<Stuff>()
                                              {
                                                  new Stuff() {Name = "Anne", CieName = "Google"},
                                                  new Stuff() {Name = "Creg", CieName = "Yahoo"}
                                              };
    
            public Form1()
            {
                InitializeComponent();
    
                BindComboBoxColumnDataSource();
            }
    
            private void BindComboBoxColumnDataSource()
            {
                var comboColumn = dataGridView1.Columns["ComboBoxColumn"] as DataGridViewComboBoxColumn;
                
                if (comboColumn != null)
                    comboColumn.DataSource = _myList;
            }
        }
