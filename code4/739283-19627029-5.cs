    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;
    namespace EnableAndDisableControlsGridviewWebApp
    {
        public partial class _Default : System.Web.UI.Page
        {
            DataTable aTable = new DataTable();
            protected void Page_Load(object sender, EventArgs e)
            {
                BindData();
            }
            private void BindData()
            {
                aTable.Columns.Add("Id", typeof(int));
                aTable.Columns.Add("CustomType", typeof(string));
                aTable.Columns.Add("CustomSave", typeof(string));
                DataRow dr1 = aTable.NewRow();
                dr1["Id"] = 1;
                dr1["CustomType"] = "qualitative randomly";
                dr1["CustomSave"] = "DropdownList";
                aTable.Rows.Add(dr1);
                DataRow dr2 = aTable.NewRow();
                dr2["Id"] = 2;
                dr2["CustomType"] = "quantitative";
                dr2["CustomSave"] = "TextBox";
                aTable.Rows.Add(dr2);
                DataRow dr3 = aTable.NewRow();
                dr3["Id"] = 3;
                dr3["CustomType"] = "qualitative randomly";
                dr3["CustomSave"] = "DropdownList";
                aTable.Rows.Add(dr3);
                DataRow dr4 = aTable.NewRow();
                dr4["Id"] = 4;
                dr4["CustomType"] = "quantitative";
                dr4["CustomSave"] = "TextBox";
                aTable.Rows.Add(dr4);
                GridView1.DataSource = aTable;
                GridView1.DataBind();
            }
            protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblIdentifier = (Label)e.Row.FindControl("lblCustomType");
                    string val = lblIdentifier.Text;
                    if (val == "quantitative")
                    {
                        ((TextBox)e.Row.FindControl("txtSave")).Visible = true;
                        ((DropDownList)e.Row.FindControl("DrpSave")).Visible = false;
                    }
                    else
                    {
                        ((TextBox)e.Row.FindControl("txtSave")).Visible = false;
                        ((DropDownList)e.Row.FindControl("DrpSave")).Visible = true;
                    }
                }
            }
        }           
    }
