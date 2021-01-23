    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    namespace TestDGV
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Panel panel2;
        private DataGridView TestGrid;
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Dock = DockStyle.Fill;
            this.panel2.Name = "panel2";
            this.panel2.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 407);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //basic grid properties
            TestGrid = new DataGridView();
            TestGrid.Dock = DockStyle.Fill;
            TestGrid.AutoGenerateColumns = false;
            TestGrid.Name = "TestGrid";
            TestGrid.ReadOnly = false;
            TestGrid.EditMode = DataGridViewEditMode.EditOnEnter;
            
            //Event handlers
            TestGrid.DataBindingComplete += TestGrid_DataBindingComplete;
            TestGrid.CurrentCellDirtyStateChanged += TestGrid_CurrentCellDirtyStateChanged;
            TestGrid.CellValueChanged += TestGrid_CellValueChanged;
            
            //columns
            var textCol = new DataGridViewTextBoxColumn();
            textCol.HeaderText = "Text";
            textCol.Name = "Text";
            textCol.DataPropertyName = "Text";
            textCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            TestGrid.Columns.Add(textCol);
            var comboCol = new DataGridViewComboBoxColumn();
            comboCol.HeaderText = "ComboBox";
            comboCol.Name = "ComboBox";
            comboCol.AutoComplete = true;
            comboCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            TestGrid.Columns.Add(comboCol);
            var resultCol = new DataGridViewTextBoxColumn();
            resultCol.HeaderText = "Result";
            resultCol.Name = "Result";
            resultCol.DataPropertyName = "Result";
            resultCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TestGrid.Columns.Add(resultCol);
            //Bind the data
            Datum.TestLoad();
            TestGrid.DataSource = Datum.Data;
            panel2.Controls.Add(TestGrid);
        }
        void TestGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            var row = TestGrid.Rows[e.RowIndex];
            var cell = row.Cells[e.ColumnIndex];
            if (cell is DataGridViewComboBoxCell)
            {
                var val = cell.Value as string;
                var datum = row.DataBoundItem as Datum;
                datum.Current = val;
                row.Cells["Result"].Value = datum.Result;
                TestGrid.InvalidateRow(e.RowIndex);
            }
        }
        void TestGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if(TestGrid.CurrentCell is DataGridViewComboBoxCell)
            {
                TestGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                TestGrid.EndEdit();
            }
        }
        void TestGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in TestGrid.Rows)
            {
                var datum = row.DataBoundItem as Datum;
                if (datum == null)
                    return;
                var cell = row.Cells["ComboBox"] as DataGridViewComboBoxCell;
                if (cell.DataSource == null)
                {
                    cell.DisplayMember = "KeyDisplayValue";
                    cell.ValueMember = "KeyValue";
                    cell.DataSource = (row.DataBoundItem as Datum).Combo;
                    cell.Value = (row.DataBoundItem as Datum).Current;
                }
            }
            TestGrid.DataBindingComplete -= TestGrid_DataBindingComplete;
        }
        public class Datum
        {
            public static void TestLoad()
            {
                var t1 = new Triplet[] {
                         new Triplet("1", "World", "Everyone" ),
                         new Triplet("2", "Charlie", "Friend of Algernon" ),
                         new Triplet("3", "Lester", "Phenomenal programmer" ),
                };
                var t2 = new Triplet[] {
                         new Triplet("1", "World", "Everyone" ),
                         new Triplet("4", "Mary", "Wife of George Bailey" ),
                         new Triplet("3", "Lester", "Phenomenal programmer" ),
                };
                Data.Add(new Datum("hello, ", t1.ToList()));
                Data.Add(new Datum("g'bye, ", t2.ToList()));
            }
            public static List<Datum> Data = new List<Datum>();
            public Datum(string text, List<Triplet> combo)
            {
                this._text = text;
                this._combo = combo.ToDictionary<Triplet,string>(o => o.KeyValue);
                this.Current = combo[0].KeyValue;
            }
            private string _text;
            public string Text
            {
                get
                {
                    return _text;
                }
            }
            private Dictionary<string, Triplet> _combo;
            public List<Triplet> Combo
            {
                get
                {
                    return _combo.Values.ToList();
                }
            }
            private string _result;
            public string Result
            {
                get
                {
                    return _result;
                }
            }
            private string _current;
            public string Current
            {
                get
                {
                    return _current;
                }
                set
                {
                    if (value != null && _combo.ContainsKey(value))
                    {
                        _current = value;
                        _result = _combo[value].Description;
                    }
                }
            }
        }
        public class Triplet
        {
            public string KeyValue { get; set; }
            public string KeyDisplayValue { get; set; }
            public string Description { get; set; }
            public Triplet(string keyValue, string keyDisplayValue, string description)
            {
                KeyValue = keyValue;
                KeyDisplayValue = keyDisplayValue;
                Description = description;
            }
        }
    }
    }
