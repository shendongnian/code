    // Change your original line in Page_Load to this... The variable name conflicts with the class name
    Dictionary<string, string> orderDictionary = (Dictionary<string, string>)Session["Order"];
    
    // Bind like this:
    GridView1.DataSource = orderDictionary.Keys;
