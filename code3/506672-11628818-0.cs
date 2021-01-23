    foreach (var ctrl in grd.Children)
            {
                if (ctrl is TextBox)
                {
                    tbox = ctrl as TextBox;
                    Point p = Mouse.GetPosition(tbox);
                    tbox.ToolTip =p.X + " " + p.Y + " \n " + tbox.TabIndex ;
                }
            }
