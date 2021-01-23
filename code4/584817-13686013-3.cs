    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;
    
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable("table1");
                dt.Columns.Add("ID", Type.GetType("System.Int32"));
                dt.Columns.Add("text1");
                dt.Columns.Add("text2");
                dt.Columns.Add("isLast", Type.GetType("System.Boolean"));
                for (int i = 0; i < 3; i++)
                {
                    dt.Rows.Add(new object[] { 
                        i, 
                        i < 2 ? "text 1 row " + i : string.Empty, 
                        i < 2 ? "text 2 row " + i : string.Empty, 
                        i == 2 });
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
                Session["dataTable"] = dt; // change to sql data source
            }
        }
        protected void DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            DataTable dt = (DataTable)Session["dataTable"];
            var maxId = dt.AsEnumerable().Max(row => Convert.ToInt32(row["ID"]));
            var dataRow = dt.AsEnumerable().Where(row => (int)row["ID"] == maxId)
                            .Select(row => row)
                            .FirstOrDefault();
            dataRow["text1"] = ((TextBox)GridView1.Rows[GridView1.Rows.Count - 1].FindControl("Text1")).Text;
            dataRow["text2"] = ((TextBox)GridView1.Rows[GridView1.Rows.Count - 1].FindControl("Text2")).Text;
            dataRow["isLast"] = false;
            dt.Rows.Add(new object[] { maxId + 1, string.Empty, string.Empty, true });
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Session["dataTable"] = dt;
        }
    }
