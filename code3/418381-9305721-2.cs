    private void GetIntrebare()
    {
        var form = HttpContext.Current.Request.Form;
        StringBuilder sb = new StringBuilder();
        sb.Append("<div>Intrebare Values: <br />");
        for (int i = 0; i < form.Count; i++)
        {
            if (form.Keys[i] == "intrebare[]")
            {
                string valuesFormat = "Value {0} : {1} <br />";
                string[] values = form[i].Split(',');
                for (int ii = 0; ii < values.Length; ii++)
                { 
                    // Label the value index + 1 to match the 'actual' dynamic textbox
                    sb.AppendFormat(valuesFormat, ii + 1, values[ii]);
                }
            }
        }
        sb.Append("</div>");
        TestResultLabel.Text = sb.ToString();
    }
 
