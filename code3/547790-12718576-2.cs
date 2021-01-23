    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    
    namespace MyNamespace
    {
        public partial class VendorListControl : System.Web.UI.UserControl
        {
            protected void Page_Load( object sender, EventArgs e ) {
                if( !IsPostBack ) {
                    FillVendors();
                }
            }
    
            private void FillVendors() {
                string strConn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection( strConn );
               
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT VendorID, VendorName FROM Vendor";
    
                DataSet objDs = new DataSet();
                SqlDataAdapter dAdapter = new SqlDataAdapter();
                dAdapter.SelectCommand = cmd; ;
                conn.Open();
                dAdapter.Fill( objDs );
                conn.Close();
    
                if( objDs.Tables[0].Rows.Count > 0 ) {
                    this.ddlVendorList.DataSource = objDs.Tables[0];
                    this.ddlVendorList.DataTextField = "VendorName";
                    this.ddlVendorList.DataValueField = "VendorID";
                    this.ddlVendorList.DataBind();
                    this.ddlVendorList.Items.Insert( 0, "-- Select --" );
                }
                else {
                    this.lblMessage.Text = "No Vendor Found";
                }
            }
        }
    }
