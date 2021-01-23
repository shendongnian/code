        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (HasControls())
            {
                foreach (Control child in Controls)
                {
                    var item = child as DataPagerFieldItem;
                    if (item == null || !item.HasControls())
                    {
                        child.RenderControl(writer);
                        continue;
                    }
                    foreach (Control ctrl in item.Controls)
                    {
                        var space = ctrl as LiteralControl;
                        if (space != null && space.Text == "&nbsp;")
                            continue;
                        // Set specific classes for li-Tag
                        var isCurrentPage = false;
                        if (ctrl is WebControl)
                        {
                            // Enabled = false -> "disabled"
                            if (!((WebControl)ctrl).Enabled)
                                writer.AddAttribute(HtmlTextWriterAttribute.Class, "disabled");
                            // there can only be one Label in the datapager -> "active"
                            if (ctrl is Label)
                            {
                                isCurrentPage = true;
                                writer.AddAttribute(HtmlTextWriterAttribute.Class, "active");
                            }
                        }
                        writer.RenderBeginTag(HtmlTextWriterTag.Li);
                        if (isCurrentPage)
                        {
                            writer.AddAttribute(HtmlTextWriterAttribute.Href, "#");
                            writer.RenderBeginTag(HtmlTextWriterTag.A);
                        }
                        ctrl.RenderControl(writer);
                        if (isCurrentPage)
                            writer.RenderEndTag();
                        writer.RenderEndTag();
                    }
                }
            }
        }
