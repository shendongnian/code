    foreach (RepeaterItem item in rpLists.Items)
                    {
    
                        if (item.Controls.Count > 0)
                        {
                            DataBoundLiteralControl dbLt = item.Controls[0] as DataBoundLiteralControl;
                            if (dbLt != null)
                            {
                                var controlCollection = this.ParseControl(dbLt.Text);
                                HtmlInputCheckBox cbInclude = (HtmlInputCheckBox) FindControl(controlCollection, "cbIncludeList");
                                if (cbInclude != null)
                                {
                                    if (cbInclude.Checked)
                                    {
                                        //your code here 
                                    }
                                }
                            }
                        }
                    }
 
