    	protected void uplPanel_Load(object sender, EventArgs e)
        {
            var arg = Request.Params.Get("__EVENTARGUMENT");
            if (arg != null)
            {
                if (arg != "")
                {
                    string recordId = arg.ToString();
                    //Do deletetion and rebind data grid
		}
	     }
	}
