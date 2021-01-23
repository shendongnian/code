    protected void catRep_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
      Control placeHolder = e.Item.FindControl("hiddenPlaceHolder");
      if (placeHolder != null)
      {
        MyItemClass my = (MyItemClass)e.Item.DataItem;
        HiddenField hf = new HiddenField();
        hf.Value = "";
        hf.ID = "categoria" + my.ID;
        placeHolder.Controls.Add(hf);
      }
    }
