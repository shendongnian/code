    foreach (UIElement el in mapGrid.Children)
            {
                XElement control = new XElement("control");
                var ele = (HumanWorkspace)el;
                Vector v = VisualTreeHelper.GetOffset(el);
                double x = v.X;
                double y = v.Y;
                XAttribute atd = new XAttribute("direction", ele.Direction.ToString("d"));
                XAttribute atx = new XAttribute("x", v.X.ToString());
                XAttribute aty = new XAttribute("y", v.Y.ToString());
                control.Add(atd);
                control.Add(atx);
                control.Add(aty);
                controls.Add(control);
            }
