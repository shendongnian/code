    PopulateData()
    {
        if (combobox1.InvokeRequired)
        {
            combobox1.Invoke(new EventHandler(delegate(object o, EventArgs a)
                {
                    PopulateData();
                }
                    ));
        }
        else
        {
            // Do your updates here...
        }
    }
