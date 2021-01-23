    private void btnOk_Click(object sender, EventArgs e)
    {
        string order_ID = DateTime.Now.Year.ToString();
        if (DateTime.Now.Month < 10)
        {
            order_ID += "0";
        }  
        order_ID += "-"; 
        order_ID += DateTime.Now.Month.ToString();
    }
