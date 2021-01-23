    using System;
    using System.Data;
    using System.Drawing;
    using System.Web.UI.WebControls;
    using System.Windows.Forms;
    //This is a test program to do the following:
    //1. Build an empty data table of 26 rows by 6 columns.
    //2. The Table is the DataSource to a DataGridView.
    //3. The DataGrid Colomns 0-3 can be filled with decimals by one of 3 NumericUpDown      controls.
    //3. For each cell in cols 0-2 there is one in cols 3-5 that holds info which NumUpDn  was used.
    //4. Each NumUpDn has specific color. The corresponding cells have the same backcolor.
    //5. When the program starts, it builds the table from the Settings, and displays the  table in the datagrid.
    //6. The cells in cols 0-2 are supposed to get the colors ad indicated in cols 3-5, but they do not.  
    namespace DataGridViewTest
    {
    public partial class Form1 : Form
    {
        DataTable fareTable = new DataTable();
        int rowIndex;
        int colIndex;
        public Form1()
        {
            InitializeComponent();
            buildFareTable("fareTable");
            // Load the table (if exists)
            if (Properties.Settings.Default.fareTable != null)
                fareTable = Properties.Settings.Default.fareTable;
            paintFareTableCells(fareTable);
        }
        //Build the initial data table of 26R X 6C
        //Columns 3-5 are used to hold the color information of cols 0-2
        public void buildFareTable(string fareTableName)
        {
            fareTable.TableName = fareTableName;
            fareTable.Columns.Add("Weekday", typeof(Decimal));
            fareTable.Columns.Add("HalfDay", typeof(Decimal));
            fareTable.Columns.Add("Weekend", typeof(Decimal));
            //Adding 3 indexing columns that will hold the tables cell group
            fareTable.Columns.Add("IWeekday", typeof(String));
            fareTable.Columns.Add("IHalfDay", typeof(String));
            fareTable.Columns.Add("Iweekend", typeof(String));
            for (rowIndex = 0; rowIndex < 26; rowIndex++)
            {
                fareTable.Rows.Add();
            }
        }
        public void paintFareTableCells(DataTable fareTable)
        {
            fareDataGrid.DataSource = fareTable;
            for (rowIndex = 0; rowIndex < 26; rowIndex++)
            {
                for (colIndex = 0; colIndex < 3; colIndex++)
                {
                    switch (fareTable.Rows[rowIndex][colIndex + 3].ToString())   //Check the color index columns 3-5
                    {
                        case "low": fareDataGrid[colIndex, rowIndex].Style.BackColor = Color.Green;  
                            break;
                        case "med": fareDataGrid[colIndex, rowIndex].Style.BackColor = Color.Yellow; 
                            break;
                        case "high": fareDataGrid[colIndex, rowIndex].Style.BackColor = Color.Red;  
                            break;
                        default:
                            break;
                    }
                    // Diagnostics: Check cell's color. At this point, Colors are OK!  
                    Color color = fareDataGrid[colIndex, rowIndex].Style.BackColor;  
                }
            }
        }
       //Update the cells by 3 NumUpDn controls.
        private void numericUpDownFareHigh_ValueChanged(object sender, EventArgs e)
        {
            editFareTableCells(sender);
        }
        private void numericUpDownFareMed_ValueChanged(object sender, EventArgs e)
        {
            editFareTableCells(sender);
        }
        private void numericUpDownFareLow_ValueChanged(object sender, EventArgs e)
        {
            editFareTableCells(sender);
        }
        public void editFareTableCells(Object sender)
        {
            foreach (DataGridViewCell cell in fareDataGrid.SelectedCells)
            {
                if (cell.ColumnIndex < 3)
                {
                    cell.Value = ((NumericUpDown)sender).Value;
                    cell.Style.BackColor = ((NumericUpDown)sender).BackColor;
                    fareDataGrid[cell.ColumnIndex + 3, cell.RowIndex].Value = ((NumericUpDown)sender).Tag;   //Uses cols 3-5 to hold cost level info.
                }
            }
        }
        //Use settings to preserve the data
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.fareTable = this.fareTable;
            Properties.Settings.Default.Save();
        }
      }
    }
 
