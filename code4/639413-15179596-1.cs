    string row = "<tr><td>item</td><td><input name=\"radio0\" type=\"radio\"/></td></tr>";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(row);
            HtmlTableRow tblRow = new HtmlTableRow();
            foreach (XmlNode node in doc.SelectSingleNode("tr").ChildNodes)
            {
                HtmlTableCell cell = new HtmlTableCell();
                cell.InnerText = node.InnerXml;
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    if (childNode.Name == "input")
                    {
                        if (childNode.Attributes["type"] != null)
                        {
                            switch (childNode.Attributes["type"].Value.ToString())
                            {
                                case "radio":
                                    HtmlInputRadioButton rad = new HtmlInputRadioButton();
                                    rad.Name = childNode.Attributes["name"].ToString();
                                    cell.Controls.Add(rad);
                                    break;
                                ///other types of input controls
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            HtmlInputButton button = new HtmlInputButton("button");
                            cell.Controls.Add(button);
                        }
                    }
                }
                tblRow.Cells.Add(cell);
            }
