    protected void Page_Load(object sender, EventArgs e)
    {
        if (ABC_DV.CurrentMode == DetailsViewMode.Edit) {
          updated_time = (TextBox)ABC_DV.FindControl("txt_updated_time");
          if(null != updated_time)
            updated_time.Text = DateTime.Now.ToString();
        }
    }
