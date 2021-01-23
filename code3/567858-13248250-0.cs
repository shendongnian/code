    void rpAcces_ItemCommand(object source, RepeaterCommandEventArgs e)
      {
      //...
      ImageButton ib = sender as ImageButton;
      TextBox titleTXT = (TextBox)e.Item.FindControl("titleRepeat");
      TextBox qtyTXT = (TextBox)e.Item.FindControl("qtyRepeat");
      TextBox uomTXT = (TextBox)e.Item.FindControl("uomRepeat");
      TextBox prepTXT = (TextBox)e.Item.FindControl("prepRepeat");
      TextBox orTXT = (TextBox)e.Item.FindControl("orRepeat");
      titleTXT.ReadOnly = false;
      qtyTXT.ReadOnly = false;
      uomTXT.ReadOnly = false;
      prepTXT.ReadOnly = false;
      orTXT.ReadOnly = false;
      //...
     }
