     void btnEvent_click(object sender, EventArgs e)
            {
                Control ctrl = ((Control)sender);
                switch (ctrl.BackColor.Name)
                { 
                    case "Red":
                        ctrl.BackColor = Color.Yellow;
                        break;
                    case "Black":
                        ctrl.BackColor = Color.White;
                        break;
                    case "White":
                        ctrl.BackColor = Color.Red;
                        break;
                    case "Yellow":
                        ctrl.BackColor = Color.Purple;
                        break;
                    default:
                        ctrl.BackColor = Color.Red;
                        break;
                }
            }
