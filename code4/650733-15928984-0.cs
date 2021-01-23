    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace gridview
    {
        public partial class Form1 : Form
        {
            bool buttonIsPressed = false;
            int rowIndex, columnIndex;
    
            public Form1()
            {
                InitializeComponent();
                completeDataGridview();
            }
    
            //this function only creates a filled DataGridView
            private void completeDataGridview()
            {
                dataGridView1.RowCount = 3;
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        dataGridView1.Rows[x].Cells[y].Value = ((char)(97 + y + 3 * x)).ToString();
                    }
                }
    
                // this part is stolen from http://stackoverflow.com/questions/7412098/fit-datagridview-size-to-rows-and-columnss-total-size
                int height = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    height += row.Height;
                }
                height += dataGridView1.ColumnHeadersHeight;
    
                int width = 0;
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    width += col.Width;
                }
                width += dataGridView1.RowHeadersWidth;
    
                dataGridView1.ClientSize = new Size(width + 2, height);
                
            }
    
            private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
            {
                buttonIsPressed = true;
                rowIndex = e.RowIndex;
                columnIndex = e.ColumnIndex;            
            }
    
            private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
            {
                if (buttonIsPressed)
                {
                    int startingRow = 0;
                    if (rowIndex > e.RowIndex)
                        startingRow = e.RowIndex;
                    else
                        startingRow = rowIndex;
    
                    //at first we have to deselect every cell
                    deselectEveryCell();
    
                    //then reselect the old ones
                    int amountOfRows = Math.Abs(rowIndex - e.RowIndex) + 1;
                    for (int x = 0; x < amountOfRows; x++)
                    {
                        dataGridView1.Rows[startingRow + x].Cells[columnIndex].Selected = true;
                    }
                }
                buttonIsPressed = false;
            }
    
            private void deselectEveryCell()
            {
                for (int x = 0; x < dataGridView1.RowCount; x++)
                {
                    for (int y = 0; y < dataGridView1.ColumnCount; y++)
                    {
                        dataGridView1.Rows[x].Cells[y].Selected = false;
                    }
                }
            }
    
            private void dataGridView1_MouseLeave(object sender, EventArgs e)
            {
                if (buttonIsPressed)
                    deselectEveryCell();
            }
        }
    }
