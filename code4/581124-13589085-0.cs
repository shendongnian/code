    foreach (var t in panel.Controls)
    {
        var textbox = t as System.Web.UI.WebControls.TextBox;
        if(textbox != null)
        {               
            textbox.Enabled = true;
        }
    }
