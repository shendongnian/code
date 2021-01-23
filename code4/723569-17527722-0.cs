    private  string getPostBackControlID()
        {
            Control control = null;
            Page page = HttpContext.Current.Handler as Page;
            if (page != null)
            {
                string ctrlname = HttpContext.Current.Request.Params["__EVENTTARGET"];
                if (ctrlname != null && ctrlname != String.Empty)
                {
                    control = page.FindControl(ctrlname);
                }
                else
                {
                    string ctrlStr = String.Empty;
                    Control c = null;
                    foreach (string ctl in HttpContext.Current.Request.Form)
                    {
                        if (ctl != null)
                        {
                            if (ctl.EndsWith(".x") || ctl.EndsWith(".y"))
                            {
                                ctrlStr = ctl.Substring(0, ctl.Length - 2);
                                c = page.FindControl(ctrlStr);
                            }
                            else
                            {
                                c = page.FindControl(ctl);
                            }
                            if (c is System.Web.UI.WebControls.Button ||
                                     c is System.Web.UI.WebControls.ImageButton)
                            {
                                control = c;
                                break;
                            }
                        }
                    }
                }
                if (control != null)
                {
                    return control.ID;
                }
                else
                    return "";
            }
            return "";
        }
