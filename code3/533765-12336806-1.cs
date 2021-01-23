    foreach (XElement ele in doc.Elements("controls"))
                {
                    var con = new HumanWorkspace();
                    con.Direction = (WorkspaceDirection)int.Parse(ele.Attribute("direction").Value);
                    con.SetValue(TranslateTransform.XProperty, double.Parse(ele.Attribute("x").Value));
                    con.SetValue(TranslateTransform.YProperty, double.Parse(ele.Attribute("y").Value));
                }
