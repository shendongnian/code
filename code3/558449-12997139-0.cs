    string val = string.Empty;
    foreach (Control cnt in this.Controls)
    {
           if(cnt is TextBox && cnt.Name.Contains("textname"))
                val = ((TextBox)cnt).Text;
    }
