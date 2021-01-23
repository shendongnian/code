    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                this.dataGridView1.CellFormatting += dataGridView1_CellFormatting;
                this.dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            }
    
            void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex != this.dataGridView1.NewRowIndex && e.ColumnIndex == 2)
                {
                    this.dataGridView1.InvalidateRow(this.dataGridView1.NewRowIndex);
                }
            }
    
            void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            {
                if (e.RowIndex == this.dataGridView1.NewRowIndex)
                {
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                    e.CellStyle.ForeColor = Color.Red;
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            e.Value = "Total";
                            break;
    
                        case 2:
                            var sum = 0.0d;
                            for (int i = 0; i < this.dataGridView1.NewRowIndex; i++)
                            {
                                var value = this.dataGridView1[2, i].Value;
                                if (value is double)
                                {
                                    sum += ((double)value);
                                }
                            }
                            e.Value = Math.Round(sum, 2);
                            break;
                        // Single line version of case 2 would be
                        // e.Value = this.dataGridView1.Rows.Cast<DataGridViewRow>().Where(a => a.Index != a.DataGridView.NewRowIndex).Select(a => (double)a.Cells[2].Value).Sum().ToString("N2");
                    }
                }
            }
    
        }
    }
