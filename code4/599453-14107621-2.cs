    void Page_Load(Object sender, EventArgs e)
      {
         // Load data for the DropDownList control only once, when the 
         // page is first loaded.
         if(!IsPostBack)
         {
            // Specify the data source and field names for the Text 
            // and Value properties of the items (ListItem objects) 
            // in the DropDownList control.
            ColorList.DataSource = CreateDataSource();
            ColorList.DataTextField = "ColorTextField";
            ColorList.DataValueField = "ColorValueField";
            // Bind the data to the control.
            ColorList.DataBind();
            // Set the default selected item, if desired.
            ColorList.SelectedIndex = 0;
         }
      }
    void Selection_Change(Object sender, EventArgs e)
      {
         // Set the background color for days in the Calendar control
         // based on the value selected by the user from the 
         // DropDownList control.
         Calendar1.DayStyle.BackColor = 
             System.Drawing.Color.FromName(ColorList.SelectedItem.Value);
      }
