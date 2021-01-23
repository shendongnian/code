    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;
    using System.Data.SqlClient;
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("Project_ID", Type.GetType("System.Int32"));
            dt.Columns.Add("ProjectName", Type.GetType("System.String"));
            DataSet dsProd = new DataSet();
            DataTable dtProd = new DataTable();
            dtProd.Columns.Add("Product_ID", Type.GetType("System.Int32"));
            dtProd.Columns.Add("Product_Name", Type.GetType("System.String"));
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=YAZEED-PC\YAZEED;Initial Catalog=ITS364_Project;Integrated Security=True";
            String strSQL = "Select Project_ID,ProjectName from project";
            SqlCommand command = new SqlCommand();
            SqlDataReader dr;
            try
            {
                conn.Open();
                command.Connection = conn;
                command.CommandText = strSQL;
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    DataRow drr = dt.NewRow();
                    drr[0] = dr[0];
                    drr[1] = dr[1];
                    dt.Rows.Add(drr);
                }
                ds.Tables.Add(dt);
                ddProj.DataValueField = "ProjectName";
                ddProj.DataTextField = "Project_ID";
                ddProj.DataSource = ds.Tables[0].DefaultView;
                ddProj.DataBind();
                txtProjName.Text = Convert.ToString(ddProj.SelectedItem.Value);
            }
            finally
            {
                conn.Close();
            }
            string strr = "Select Product_ID, Product_Name from Products";
            try
            {
                conn.Open();
                command.Connection = conn;
                command.CommandText = strr;
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    DataRow drr = dtProd.NewRow();
                    drr[0] = dr[0];
                    drr[1] = dr[1];
                    dtProd.Rows.Add(drr);
                }
                dsProd.Tables.Add(dtProd);
                ddProd.DataValueField = "Product_ID";
                ddProd.DataTextField = "Product_Name";
                ddProd.DataSource = dsProd.Tables[0].DefaultView;
                ddProd.DataBind();
                if (ddProd.SelectedIndex != -1)
                {
                    txtProdQuantity.Text = getQuan(Convert.ToInt32(ddProd.SelectedValue));
                    fillQtyCombo();
                }
            }
            finally
            {
                conn.Close();
            }
        }
    }
    protected string getQuan(int val)
    {
        string str;
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = @"Data Source=YAZEED-PC\YAZEED;Initial Catalog=ITS364_Project;Integrated Security=True";
        conn.Open();
        String strSQL = "Select Product_Qty from Products where Product_ID = " + val + "";
        SqlCommand command = new SqlCommand();
        command.Connection = conn;
        command.CommandText = strSQL;
        str = Convert.ToString(command.ExecuteScalar());
        return str;
    }
    protected void btnAssignProducts_Click(object sender, EventArgs e)
    {
        if (txtTaskName.Text == string.Empty)
        {
            msg.Text = "";
            this.error.Text = "Please enter Task Name";
        }
        else if (ddProj.SelectedIndex == -1)
        {
            msg.Text = "";
            this.error.Text = "Please Select Project";
        }
        else if (ddProd.SelectedIndex == -1)
        {
            msg.Text = "";
            this.error.Text = "Please select Product";
        }
        else if (Convert.ToInt32(ddProdQuantity.SelectedValue) == 0)
        {
            msg.Text = "";
            this.error.Text = "Please select Product Quantity ";
        }
        else
        {
            int rtn = 0;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=YAZEED-PC\YAZEED;Initial Catalog=ITS364_Project;Integrated Security=True";
            conn.Open();
            //String strSQL = "INSERT INTO Product_task (Project_ID,Product_ID,Product_Task_desc,Product_Task_Qty) values ("+ddProj.SelectedValue+","+ddProd.SelectedValue+",'"+txtTaskName.Text+"',"+ddProdQuantity.SelectedValue+")";
            String strSQL = "INSERT INTO Product_task (Project_ID,Product_ID,Product_Task_desc) values (" + Convert.ToInt32(ddProj.SelectedItem.Text) + "," + ddProd.SelectedValue + ",'" + txtTaskName.Text + "')";
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = strSQL;
            rtn = Convert.ToInt32(command.ExecuteNonQuery());
            if (rtn > 0)
            {
                error.Text = "";
                msg.Text = "Record Saved Successfully";
            }
            else
            {
                msg.Text = "";
                error.Text = "Record Not saved Successfully, Kindly Try again.";
            }
        }
    }
    protected void ddProj_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtProjName.Text = Convert.ToString(ddProj.SelectedItem.Value);
    }
    protected void ddProd_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddProd.SelectedIndex != -1)
        {
            txtProdQuantity.Text = getQuan(Convert.ToInt32(ddProd.SelectedValue));
            fillQtyCombo();
        }
    }
    protected void fillQtyCombo()
    {
        if (ddProd.SelectedIndex != -1)
        {
            int val = Convert.ToInt32(getQuan(Convert.ToInt32(ddProd.SelectedValue)));
            DataSet dsQty = new DataSet();
            DataTable dtQty = new DataTable();
            dtQty.Columns.Add("ID", Type.GetType("System.Int32"));
            dtQty.Columns.Add("VAL", Type.GetType("System.String"));
            for (int i = 1; val >= i; i++)
            {
                DataRow drr = dtQty.NewRow();
                drr[0] = i;
                drr[1] = i;
                dtQty.Rows.Add(drr);
            }
            dsQty.Tables.Add(dtQty);
            ddProdQuantity.DataValueField = "ID";
            ddProdQuantity.DataTextField = "VAL";
            ddProdQuantity.DataSource = dsQty.Tables[0].DefaultView;
            ddProdQuantity.DataBind();
        }
    }
}
