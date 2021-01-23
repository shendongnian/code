    public void CenterControls(List<Control> controls, Direction direction)
        {
            if (controls.Count > 1)
            {
                int xSum = 0;
                int ySum = 0;
                int controls_sum_width = 0;
                int controls_seperation = 20;
                int parentwidth = 0;               
                Point center;
                foreach (Control ctl in controls)
                {
                    center = new Point(ctl.Location.X + ctl.Width / 2, ctl.Location.Y + ctl.Height / 2);
                    ySum = ySum + center.Y;
                    controls_sum_width = controls_sum_width + ctl.Width + controls_seperation;
                }
                Point average = new Point(xSum / controls.Count, ySum / controls.Count);
                center = new Point(controls[0].Parent.Width / 2, controls[0].Parent.Height / 2);
                parentwidth = controls[0].Parent.Width;
                int xoffset = (parentwidth - controls_sum_width) / 2;
                int yOffset = center.Y - average.Y;
                
                int Location_X = 0;
                foreach (Control ctl in controls)
                {
                    switch (direction)
                    {
                        case Direction.Vertical:
                            ctl.Location = new Point(ctl.Location.X + xoffset, ctl.Location.Y);
                            break;
                        case Direction.Horizontal:
                            ctl.Location = new Point(ctl.Location.X, ctl.Location.Y + yOffset);
                            break;
                        case Direction.Both:
                            ctl.Location = new Point(Location_X + xoffset, ctl.Location.Y + yOffset);
                            break;
                    }
                    Location_X = Location_X + ctl.Width+ controls_seperation;
                }
            }
            else
            {
                Point parent_center;
                Point center;
                parent_center = new Point(controls[0].Parent.Width / 2, controls[0].Parent.Height / 2);
                center = new Point(controls[0].Location.X + controls[0].Width / 2, controls[0].Location.Y + controls[0].Height / 2);
                int xOffset = parent_center.X - center.X;
                int yOffset = parent_center.Y - center.Y;
                switch (direction)
                {
                    case Direction.Vertical:
                        controls[0].Location = new Point(controls[0].Location.X + xOffset, controls[0].Location.Y);
                        break;
                    case Direction.Horizontal:
                        controls[0].Location = new Point(controls[0].Location.X, controls[0].Location.Y + yOffset);
                        break;
                    case Direction.Both:
                        controls[0].Location = new Point(controls[0].Location.X + xOffset, controls[0].Location.Y + yOffset);
                        break;
                }
            }
        }
        public void GetAllControl(Control c, List<Control> list)
        {
            //gets all controls and saves them to a list
            foreach (Control control in c.Controls)
            {
                list.Add(control);
            }
        }
    
