        public class DropDownListAdapter : System.Web.UI.WebControls.Adapters.WebControlAdapter {
        protected override void RenderContents(HtmlTextWriter writer) {
            var dropDownList = (DropDownList)Control;
            var items = dropDownList.Items;
            var groups = (from p in items.OfType<ListItem>()
                          group p by p.Attributes["Group"] into g
                          select new { Label = g.Key, Items = g.ToList() });
            foreach (var group in groups)
            {
                if (!String.IsNullOrEmpty(group.Label))
                {
                    writer.WriteBeginTag("optgroup");
                    writer.WriteAttribute("label", group.Label);
                    writer.Write(">");
                }
                var count = group.Items.Count();
                if (count > 0)
                {
                    var flag = false;
                    for (var i = 0; i < count; i++)
                    {
                        var item = group.Items[i];
                        writer.WriteBeginTag("option");
                        if (item.Selected)
                        {
                            if (flag)
                            {
                                throw new HttpException("Multiple selected items not allowed");
                            }
                            flag = true;
                            writer.WriteAttribute("selected", "selected");
                        }
                        if (!item.Enabled)
                        {
                            writer.WriteAttribute("disabled", "true");
                        }
                        writer.WriteAttribute("value", item.Value, true);
                        if (Page != null)
                        {
                            Page.ClientScript.RegisterForEventValidation(dropDownList.UniqueID, item.Value);
                        }
                        writer.Write('>');
                        HttpUtility.HtmlEncode(item.Text, writer);
                        writer.WriteEndTag("option");
                        writer.WriteLine();
                    }
                }
                if (!String.IsNullOrEmpty(group.Label))
                {
                    writer.WriteEndTag("optgroup");
                }
            }
        }
    }
