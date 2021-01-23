    protected void menu_ItemClick(object sender, Telerik.Web.UI.RadMenuEventArgs e)
     {
          string value = (e.Item.Value).ToString();
          WtrClientDS.SelectParameters.Add(new Parameter("LocId", System.TypeCode.Int32, value));
          //refresh your control
          WtrClients.DataSource = WtrClientDS;
          WtrClients.Rebind();
     }
