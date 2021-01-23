    private void FrmDelivery_Load(object sender, EventArgs e)
    {
        if (theDelivery != null)
        {
            txtCustomerName.Text = theDelivery.customerName;
            txtCustomerAddress.Text = theDelivery.customerAddress;
            txtArrivalTime.Text = theDelivery.arrivalTime;      
        }
    } 
    
    private void btnSave_Click(object sender, System.EventArgs e)
    {
        string line = string.Format("{0},{1},{2}"
                    , txtCustomerName.Text 
                    , txtArrivalTime.Text  
                    , theDelivery.arrivalTime);
        File.AppendAllText("visits.txt", line);   
    }
