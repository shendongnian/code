    [WebMethod]
    public int SaveSelectedOffers(IList<string> offers, int selectedRows)
    {
    
    }
    private void offersAvailableSubmit_Click(object sender, EventArgs e)
    {
        IList<string> options = new List<string>();
        options.Add("item 1");
        options.Add("item 2");
        options.Add("item 2");
        int rowsAffected = serviceCaller.SaveSelectedOffers(options, rowCount); 
    }
