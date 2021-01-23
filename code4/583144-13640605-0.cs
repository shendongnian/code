    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                DataTable dt = new DataTable("table1");
                dt.Columns.Add("ID", Type.GetType("System.Int32"));
                dt.Columns.Add("CHECK", Type.GetType("System.Boolean"));
                dt.Columns.Add("DAY");
                for (int i = 0; i < 10; i++)
                    dt.Rows.Add(new object[] {i, false, "Option " + i});
                gridControl1.DataSource = dt;
            }
    
            /// <summary>
            /// Extract checked rows
            /// </summary>
            private void simpleButton1_Click(object sender, EventArgs e)
            {
                memoEdit1.Text = string.Empty;
                StringBuilder sb = new StringBuilder();
                foreach (var row in ((DataTable)gridControl1.DataSource).AsEnumerable().Where(row => (bool)row["CHECK"]))
                    sb.Append(String.Format("{0}, {1}, {2}\r\n", row["ID"], row["CHECK"], row["DAY"]));
                memoEdit1.Text = sb.ToString();
            }
    
            /// <summary>
            /// Extract selected rows
            /// </summary>
            private void simpleButton2_Click(object sender, EventArgs e)
            {
                memoEdit1.Text = string.Empty;
                StringBuilder sb = new StringBuilder();
                foreach (int rowIndex in gridView1.GetSelectedRows())
                {
                    DataRow row = gridView1.GetDataRow(rowIndex);
                    sb.Append(String.Format("{0}, {1}, {2}\r\n", row["ID"], row["CHECK"], row["DAY"]));
                }
                memoEdit1.Text = sb.ToString();
            }
    
        }
    }
