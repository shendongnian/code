    private void button_Search_Click(object sender, EventArgs e)
    {
      using (var model = new SuburbanPortalEntities())
      {
        var qry = (from logs in model.Logs
                  select logs).ToList();
    Guid corpid;
    if (Guid.TryParse(textBox_CorporationGuid.Text, out corpid))
    {
      qry.Concat((from logs in model.Logs
                where logs.CorporationId == corpid
                select logs).ToList());
    }
    Guid tokenid;
    if (Guid.TryParse(textBox_TokenId.Text, out tokenid))
    {
      qry.Concat(from logs in model.Logs
            where logs.TokenId == tokenid
            orderby logs.LogDateTime descending 
            select logs).ToList());
    }
    if (checkBox_DisplayErrors.Checked)
    {
      qry.Concat((from logs in model.Logs
            where logs.IsException
            select logs).ToList());
    }
    if (checkBox_DisplayWarnings.Checked)
    {
      qry.Concat((from logs in model.Logs
            where logs.IsWarning
            select logs).ToList());
    }
    dataGridView1.DataSource = qry;
  }
}
