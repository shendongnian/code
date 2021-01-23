    protected void cmdSearch_Click(object sender, EventArgs e)
    {
        Text = txtSearch.Text;
        Text2 = txtSearch2.Text;
        Text3 = txtSearch3.Text;
        Response.Redirect(string.Format("search.aspx?txtSearch={0}&txtSearch2={1}&txtSearch3={2}", Text, Text2, Tex3));
    }
