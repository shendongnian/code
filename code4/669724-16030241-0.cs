    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        LoadData();
      }
    }
    
    private void LoadData()
    {
      // this.List1 refers to the DropDownList control defined in your page markup
      DropDownList list = this.List1; 
    
      IList<Tuple<string, string>> items = /* Getting items from the database */;
      int selectedItemIndex = /* Getting the selected item index */;
    
      for (int i = 0; i < items.Count; i++)
      {
        list.Items.Add(new ListItem(items[i].Item1, items[i].Item2, i == selectedItemIndex));
      }
    }
