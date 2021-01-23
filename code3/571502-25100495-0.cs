    using System;
    using System.Windows.Forms;
    
    namespace Check_UnCheck_All
    {
        public partial class Check_UnCheck_All : Form
        {
            public Check_UnCheck_All()
            {
                InitializeComponent();
                dataGridView1.RowCount = 10;
                dataGridView1.AllowUserToAddRows = false;
                this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApps_CellContentClick);
                this.dataGridView1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.myDataGrid_OnCellMouseUp);
                this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.myDataGrid_OnCellValueChanged);
                this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
            }
    
            public int chkInt = 0;
            public bool chked = false;
    
            public void myDataGrid_OnCellValueChanged(object sender, DataGridViewCellEventArgs e)
            {
                if (e.ColumnIndex == dataGridView1.Rows[0].Index && e.RowIndex != -1)
                {
                    DataGridViewCheckBoxCell chk = dataGridView1.Rows[e.RowIndex].Cells[0] as DataGridViewCheckBoxCell;
    
                    if (Convert.ToBoolean(chk.Value) == true) chkInt++;
                    if (Convert.ToBoolean(chk.Value) == false) chkInt--;
                    if (chkInt < dataGridView1.Rows.Count && chkInt > 0)
                    {
                        checkBox1.CheckState = CheckState.Indeterminate;
                        chked = true;
                    }
                    else if (chkInt == 0)
                    {
                        checkBox1.CheckState = CheckState.Unchecked;
                        chked = false;
                    }
                    else if (chkInt == dataGridView1.Rows.Count)
                    {
                        checkBox1.CheckState = CheckState.Checked;
                        chked = true;
                    }
                }
            }
            public void myDataGrid_OnCellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
            {
                // End of edition on each click on column of checkbox
                if (e.ColumnIndex == dataGridView1.Rows[0].Index && e.RowIndex != -1)
                {
                    dataGridView1.EndEdit();
                }
                dataGridView1.BeginEdit(true);
            }
            public void dgvApps_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                if (dataGridView1.CurrentCell.GetType() == typeof(DataGridViewCheckBoxCell))
                {
                    if (dataGridView1.CurrentCell.IsInEditMode)
                    {
                        if (dataGridView1.IsCurrentCellDirty)
                        {
                            dataGridView1.EndEdit();
                        }
                    }
                    dataGridView1.BeginEdit(true);
                }
            }
            public void checkBox1_Click(object sender, EventArgs e)
            {
                if (chked == true)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                        if (chk.Value == chk.TrueValue)
                        {
                            chk.Value = chk.FalseValue;
                        }
                        else
                        {
                            chk.Value = chk.TrueValue;
                        }
                    }
                    chked = false;
                    chkInt = 0;
                    return;
                }
                if (chked == false)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        dataGridView1.Rows[row.Index].SetValues(true);
                    }
                    chked = true;
                    chkInt = dataGridView1.Rows.Count;
                }
            }
        }
    }
