    switch (ctrlThis.GetType().ToString())
    {
    	case "System.Web.UI.WebControls.TextBox" :
    	        TextBox txtThis = (TextBox)ctrlThis;
                    if (txtThis.Text == "" || txtThis.Text == null)
                    { return false; }
                    break;
    }
