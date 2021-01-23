    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace Test2
    {
        public partial class DynamicControls : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected override void OnPreInit(EventArgs e)
            {
                base.OnPreInit(e);
                CreateTextBoxesInTable();
            }
    
            private void CreateTextBoxesInTable()
            {
                PHDynamicTable.Controls.Clear();
                
                List<string> X = new List<string>() { "A", "B", "C" };
                List<string> Y = new List<string>() { "1", "2", "3", "4" };
    
                Table table = new Table();
                table.ID = "dynamicTable";
    
                TableRow tr;
                foreach (string y in Y)
                {
                    tr = new TableRow();
    
                    foreach (string x in X)
                    { 
                        TableCell tc = new TableCell();
    
                        TextBox textBox = new TextBox();
                        textBox.ID = "txt_" + x + y;
                        tc.Controls.Add(textBox);
    
                        tr.Cells.Add(tc);
                    }
    
                    table.Rows.Add(tr);
                }
    
                PHDynamicTable.Controls.Add(table);
            }
    
            protected void btnSubmit_Click(object sender, EventArgs e)
            {
                if (PHDynamicTable.Controls.Count > 0)
                {
                    Table dynamicTable = (Table)PHDynamicTable.FindControl("dynamicTable");
                    if (dynamicTable != null)
                    {
                        foreach (TableRow tr in dynamicTable.Rows)
                        {
                            foreach (TableCell tc in tr.Cells)
                            {
                                TextBox textBox = (TextBox)tc.Controls[0];
                                string text = textBox.Text;
                                //Do whatever you want with the control
                            }
                        }
                    }
                }
            }
        }
    }
