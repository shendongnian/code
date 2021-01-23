    protected void Search(object sender, EventArgs e)
    {
        List<PostalCode> codes = new List<PostalCode>()
        {
            new PostalCode{ Code="000",Province="District 0" },
            new PostalCode{ Code="111",Province="District 1" }
        };
        string code = txtPostcode.Text;
        if (codes.Where(c => c.Code == code).Any())
        {
            GridView1.DataSource = codes.Where(c => c.Code == code);
            GridView1.DataBind();
            ModalPopupExtender1.Show();
        }
    }
