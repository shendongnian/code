       public enum Direction
        {
            Vertical,
            Horizontal,
            Both
        }
        public void CenterControls(List<Control> controls, Direction direction)
        {
            if (controls.Count > 1)
            {
                 int controls_sum_width = 0;
                int controls_seperation = 20;
                int parentwidth = 0;               
                Point center;
                foreach (Control ctl in controls)
                {
                     controls_sum_width = controls_sum_width + ctl.Width + controls_seperation;
                }
            
                Point Container_center = new Point(controls[0].Parent.Width / 2, controls[0].Parent.Height / 2);
                parentwidth = controls[0].Parent.Width;
                int xoffset = (parentwidth - controls_sum_width) / 2;
               
                
                int Location_X = 0;
                foreach (Control ctl in controls)
                {
                    center = new Point( ctl.Width / 2,  ctl.Height / 2);
                    int yOffset = Container_center.Y - center.Y;
                    switch (direction)
                    {
                        case Direction.Vertical:
                            ctl.Location = new Point(ctl.Location.X + xoffset, ctl.Location.Y);
                            break;
                        case Direction.Horizontal:
                            ctl.Location = new Point(ctl.Location.X, yOffset);
                            break;
                        case Direction.Both:
                            ctl.Location = new Point(Location_X + xoffset,  yOffset);
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
    
    
