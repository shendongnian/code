    private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        string sdsd = serialPort1.ReadLine();
        string Hexed = new LasalleRFIDComputerRentals.BLL.DAL.Utils().HexIt(sdsd);
        SetRFIDText(Hexed);
    }
    protected void SetRFIDText(string input)
    {
        this.Invoke(new Function(delegate()
        {
            txtRFID.Text = input;
        }));
        // what is it for?
        //CustomerInfo customer = new Customer().GetCustomerByRFID(txtRFID.Text);
        
        SearchCustomer();
    }
    private void btnOk_Click(object sender, EventArgs e)
    {
        SearchCustomer();
    }
    private void SearchCustomer()
    {
        if (txtRFID.Text.Trim() == "")
        {
            MessageBox.Show(this, "Please supply the RFID.", "RFID Reader", MessageBoxButtons.OK);
            txtRFID.Focus();
            return;
        }
        CustomerInfo customer = new Customer().GetCustomerByRFID(txtRFID.Text);
        if (customer.CustomerID <= 0)
        {
            MessageBox.Show("Invalid RFID", "Validation");
            this.Close();
            return;
        }
        if (_parentForm == "StandBy")
        {
            Utils.CurrentCustomer.CustomerInfo = customer;
            frmStandBy form = (frmStandBy)this.Owner;
            form.xResult = "OK";
        }
        // what is it for?
        //this.Close();
    }
