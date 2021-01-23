    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;
    
    public partial class DataGridTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> ddData = new List<string>();
                ddData.Add("Col 21");
                ddData.Add("Col 22");
                ddData.Add("Col 23");
    
                this.DropDownList1.DataSource = ddData;
                this.DropDownList1.DataBind();
    
                DataTable gridData = new DataTable();
                gridData.Columns.Add("Description");
                gridData.Columns.Add("Column 1");
                gridData.Columns.Add("Column 2");
                gridData.Columns.Add("Column 3");
    
                gridData.Rows.Add("Row 1", "Col 11", "Col 21", "Col 31");
                gridData.Rows.Add("Row 2", "Col 12", "Col 22", "Col 32");
                gridData.Rows.Add("Row 3", "Col 13", "Col 23", "Col 33");
                gridData.Rows.Add("Row 3", "Col 14", "Col 22", "Col 34");
    
                this.GridView1.DataSource = gridData;
                this.GridView1.DataBind();
            }
        }
    
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                this.GridView1.Rows[i].Visible = true;
    
                string cellvalue = GridView1.Rows[i].Cells[2].Text;
                if (cellvalue.TrimEnd() != this.DropDownList1.SelectedItem.Value.TrimEnd())
                    GridView1.Rows[i].Visible = false;
            }
        }
    }
