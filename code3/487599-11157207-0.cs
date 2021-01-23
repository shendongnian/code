     foreach (GridViewRow row in gvLineItems.Rows)
                {
                   HtmlInputHidden hiddenField = (HtmlInputHidden)row.FindControl("hdnIsChanged");
                   RadioButtonList rbl2 = (RadioButtonList)row.FindControl("rbAnswer");
                   
                  foreach (ListItem li in rbl2.Items)
                   {
                       li.Attributes.Add("onclick", "document.getElementById('" + hiddenField.ClientID + "').value=1");
                   }
                }
