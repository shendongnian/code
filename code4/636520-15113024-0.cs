    if (Page.IsPostBack)
    {
        string name = "txtBoxcustom";
        foreach (string key in Request.Form.Keys)
        {
            int index = key.IndexOf(name);
            if (index >= 0)
            {
                int num = Int32.Parse(key.Substring(index + name.Length));
                string value = Request.Form[key];
                //store value of txtBoxcustom with that number to database...
            }
        }
    }
