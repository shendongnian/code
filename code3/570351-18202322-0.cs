    var cnt = FindControl(formViewTemplate.Row, "controlName");
                var htmlControl = cnt as HtmlControl;
                if (htmlControl != null)
                {//---------------------}
    private Control FindControl(Control parent, string id)
        {
            foreach (Control child in parent.Controls)
            {
                string childId = string.Empty;
                if (child.ID != null)
                {
                    childId = child.ID;
                }
                if (childId.ToLower() == id.ToLower())
                {
                    return child;
                }
                if (child.HasControls())
                {
                    Control response = FindControl(child, id);
                    if (response != null)
                        return response;
                }
            }
            return null;
        }
