    if (!IsPostBack)
                {
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
