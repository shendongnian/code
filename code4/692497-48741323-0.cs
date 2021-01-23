    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Excel;
    using System.IO;
    
    namespace TEST3
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            DataSet result;
    
            private void btnOpen_Click(object sender, EventArgs e)
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Wprkbook 97-2003|*.xls| Excel Workbook|*.xlsx", ValidateNames = true })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        FileStream fs = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read);
                        IExcelDataReader reader;
                        if (ofd.FilterIndex == 1)
                            reader = ExcelReaderFactory.CreateBinaryReader(fs);
                        else
                            reader = ExcelReaderFactory.CreateOpenXmlReader(fs);
                        reader.IsFirstRowAsColumnNames = true;
                        result = reader.AsDataSet();
                        cboSheet.Items.Clear();
                        foreach (DataTable dt in result.Tables)
                            cboSheet.Items.Add(dt.TableName);
                        reader.Close();
    
                    }
                }
            }
    
            private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
    
            }
    
    
            private void cbosheet_SelectedIndexChanged(object sender, EventArgs e)
            {
                dataGridView.DataSource = result.Tables[cboSheet.SelectedIndex];
            }
        }
    }
