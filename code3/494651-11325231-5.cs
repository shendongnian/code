    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Collections;
    using System.Data;
    
    public partial class GridViewTest : System.Web.UI.Page
    {
        public readonly int FullDayHours = 8;
        public readonly int HalfDayHours = 4;
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable gridViewSource = new DataTable();
    
                DataColumn oneColumn = new DataColumn("SomeOtherField");
                oneColumn.DataType = System.Type.GetType("System.String");
                gridViewSource.Columns.Add(oneColumn);
    
                oneColumn = new DataColumn("HoursField");
                oneColumn.DataType = System.Type.GetType("System.Int32");
                gridViewSource.Columns.Add(oneColumn);
    
                for (int i = 0; i < 10; i++)
                {
                    DataRow oneRow = gridViewSource.NewRow();
                    oneRow["SomeOtherField"] = "Other field " + i.ToString();
                    oneRow["HoursField"] = i;
                    gridViewSource.Rows.Add(oneRow);
                }
                example.DataSource = gridViewSource;
                example.DataBind();
            }
        }
    }
