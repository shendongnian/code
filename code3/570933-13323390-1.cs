    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        // Create some fake data and bind it to the gridview
        var data = new List<TheData>();
        foreach(var num in Enumerable.Range(1, 4))
        {
          var newData = new TheData();
          newData.Number = num.ToString();
          newData.Value = num;
          data.Add(newData);
        }
        gvData.DataSource = data;
        gvData.DataBind();
      }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      for (var index = 0; index < gvData.Rows.Count; ++index)
      {
        var row = gvData.Rows[index];
        var lblLabel = row.FindControl("lblLabel") as Label;
        var txtData = row.FindControl("txtData") as TextBox;
        //Here is where the values are grabbed, at this point you can do what you need to.
        var number = lblLabel.Text;
        var value = txtData.Text;
      }
    }
