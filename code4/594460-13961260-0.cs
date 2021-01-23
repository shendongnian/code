    for (int i = 0; i < node.ChildNodes.Count; i++)
                {
    
                    lbl = new Label();
                    lbl.Text = node.ChildNodes[i].Name + " = " + node.ChildNodes[i].InnerText;
                    lbl.top = 15 * i;
                    panel1.Controls.Add(lbl);
    }
