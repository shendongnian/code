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
