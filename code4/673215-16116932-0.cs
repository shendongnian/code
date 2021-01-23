    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using MySql.Data.Common;
    using MySql.Data.MySqlClient;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    using System.Data;
    
    public partial class viewAdmin : System.Web.UI.Page
    {
        String MyConString = "SERVER=localhost;" +
                    "DATABASE=databasename;" +
                    "UID=root;" +
                    "PASSWORD=;";
    protected void Page_Load(object sender, EventArgs e)
    {
            
            MySqlConnection conn = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tablename;", conn);
            conn.Open();
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
    
            da.Fill(dataTable);
    
    
            GridVIew.DataSource = dataTable;
            GridVIew.DataBind();
    }
    
    }
