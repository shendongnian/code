    //Page_Load Event
    if (!Page.IsPostBack)
        {
             DataBaseDataContext db = new DataBaseDataContext();
             var Item = db.FirstOrDefault(k => k.ID == SomeID);
             NameTextBox.Text = Item.Name;
             PriceTextBox.Text = Item.Price.ToString();  
        }
