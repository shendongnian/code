    using System;
    using System.Web.UI;
    using System.Data;
    
    
    public partial class Default6 : System.Web.UI.Page
    {
        DataTable _dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                _dt = new DataTable();
                _dt = CreateDataTable();
                Session["DataTable"] = _dt;
                aspGrid1.DataSource = ((DataTable)Session["DataTable"]).DefaultView;
                aspGrid1.DataBind();
            }
         
        }
        protected void btnSumbit_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == " ")
            {
                return;
            }
            else if (TextBox1.Text != string.Empty)
            {
    
                AddDataTable(TextBox1.Text, (DataTable)Session["DataTable"]);
                aspGrid1.DataSource = ((DataTable)Session["DataTable"]).DefaultView;
                aspGrid1.DataBind();
            }
           
        }
    
        private DataTable CreateDataTable()
        {
            DataTable datatable=new DataTable();
    
            DataColumn datacolumn=new DataColumn();
            datacolumn.ColumnName = "Name";
            datacolumn.DataType = Type.GetType("System.String");
            datatable.Columns.Add(datacolumn);
            return datatable;
        }
        private void AddDataTable(string name,DataTable datatable)
        {
    
            DataRow dataRow;
            dataRow = datatable.NewRow();
            dataRow["Name"] = name;
            datatable.Rows.Add(dataRow);
        }
    }
