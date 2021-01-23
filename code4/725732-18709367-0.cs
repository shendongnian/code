    public override void ExtractValuesFromCell(System.Collections.Specialized.IOrderedDictionary dictionary, DataControlFieldCell cell, DataControlRowState rowState, bool includeReadOnly)
    {
        Control control = null;
        string dataField = DataField;
        object text = null;
        string nullDisplayText = NullDisplayText;
        if (((rowState & DataControlRowState.Insert) == DataControlRowState.Normal) || InsertVisible)
        {
            if (cell.Controls.Count > 0)
            {
                foreach (Control c in cell.Controls)
                {
                    control = cell.Controls[0];
                            
                    if (c is TextBox)
                    {
                        text = ((TextBox)c).Text;
                    } 
                }
            }
            else if (includeReadOnly)
            {
                string s = cell.Text;
                if (s == "&nbsp;")
                {
                    text = string.Empty;
                }
                else if (SupportsHtmlEncode && HtmlEncode)
                {
                    text = HttpUtility.HtmlDecode(s);
                }
                else
                {
                    text = s;
                }
            }
            if (text != null)
            {
                if (((text is string) && (((string)text).Length == 0)) && ConvertEmptyStringToNull)
                {
                    text = null;
                }
                if (((text is string) && (((string)text) == nullDisplayText)) && (nullDisplayText.Length > 0))
                {
                    text = null;
                }
                if (dictionary.Contains(dataField))
                {
                    dictionary[dataField] = text;
                }
                else
                {
                    dictionary.Add(dataField, text);
                }
            }
        }
    }
