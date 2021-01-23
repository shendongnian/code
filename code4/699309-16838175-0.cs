    gridSearchResults = new GridView { 
        AutoGenerateColumns=false,
        // other properties...
    };
    gridSearchResults.Columns.Add(new HyperLinkField {
        HeaderText = "MyLink",
        DataTextField = "MyField"
        // and so on
    });
