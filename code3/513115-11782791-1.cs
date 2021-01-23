    if (Page.IsPostBack)
    {
       // Retrieve and display the property value.
       Response.Write(strColor);
    }
    else
       // Save the property value.
       strColor = "yellow";
