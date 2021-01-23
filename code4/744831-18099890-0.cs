    protected void Page_Load(object sender, EventArgs e)
    {
         if (!this.IsPostBack)
         {
              myDictionary.Add("1", "Test Address 1");
              myDictionary.Add("2", "Test Address 2");
              myDictionary.Add("3", "Test Address 3");
              myDictionary.Add("4", "Test Address 4");
              myDictionary.Add("5", "Test Address 5");
    
              drpTest.DataSource = myDictionary;
              drpTest.DataTextField = "Key";
              drpTest.DataValueField = "Value";
              drpTest.DataBind();
    
              drpTest.SelectedIndex = 2;
              lblAddress.Text = drpTest.SelectedItem.Value;     **// add this**
         }
    }
