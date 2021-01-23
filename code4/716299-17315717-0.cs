    private void bindGrid(string sort)
    {
        try
        {
            if (int.Parse(lblAccountNo.Text.ToString()) > 0)
                _clientTransection.AccountNo = Convert.ToInt32(lblAccountNo.Text.ToString());
            Collection<ClientTransInvoiceRows> _clientList = _clientTransection.Execute();
            if (string.IsNullOrEmpty(sort))
            {
                // apply sorting
            }
            GridView1.DataSource = _clientList;
            GridView1.DataBind();
        }
        catch
        {
        }
    }
