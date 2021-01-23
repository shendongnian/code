    protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                 // Put your code inside this.
                 string id = Request.QueryString["id"];
                 OleDbConnection conn = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" + Server.MapPath("path to DB"));
        OleDbCommand comm = new OleDbCommand("select * from table where ID=" + id, conn);
        OleDbDataReader reader;
        conn.Open();
        reader = comm.ExecuteReader();
        reader.Read();
        ddlType.SelectedIndex = (Convert.ToInt32(reader["PersonType"]) - 1); // -1 to fix position, list is zero based. type 1(0) = PP type 2(1) = DC
        txtFirstName.Text = reader["FirstName"].ToString();
        txtLastName.Text = reader["LastName"].ToString();
        txtAddress.Text = reader["Address"].ToString();
        txtCountry.Text = reader["Country"].ToString();
        txtPhone.Text = reader["Phone"].ToString();
        txtFax.Text = reader["Fax"].ToString();
        txtClinic.Text = reader["Clinic"].ToString();
        txtReferredBy.Text = reader["ReferingFactor"].ToString();
        txtWebSite.Text = reader["WebSite"].ToString();
        txtReceiptNumber.Text = reader["Receipt"].ToString();
        txtDeviceType.Text = reader["DeviceType"].ToString();
        txtDeviceSerialNumber.Text = reader["DeviceSerialNumber"].ToString();
        txtPaymentType.Text = reader["PaymentType"].ToString();
        txtDevicePrice.Text = reader["DevicePrice"].ToString();
        txtClientUserName.Text = reader["PersonUserName"].ToString();
        txtClientPassword.Text = reader["PersonPassword"].ToString();
        txtComments.Text = reader["Comment"].ToString();
                }
     
            }
