    public static class CmponentsExtensions
    {
      //Management of mouse drag and drop
        #region Menu and Mouse
        private static bool mouseDown;
        private static Point lastLocation;
        
        /// <summary>
        /// To enable control to be moved around with mouse
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        public static void moveItselfWithMouse<T>(this T control) where T: Control
        { 
            control.MouseDown += (o, e)=> { mouseDown = true; lastLocation = e.Location; };
            control.MouseMove += (o, e) => 
            {
                if (mouseDown)
                {
                    control.Location = new Point((control.Location.X - lastLocation.X) + e.X, (control.Location.Y - lastLocation.Y) + e.Y);
                    control.Update();
                }
            };
            control.MouseUp += (o, e) => { mouseDown = false; } ;
        }
    
    
        public static void moveOtherWithMouse<T>(this T control, Control movedObject) where T : Control
        {
            control.MouseDown += (o, e) => { mouseDown = true; lastLocation = e.Location; };
            control.MouseMove += (o, e) =>
            {
                if (mouseDown)
                { 
                    movedObject.Location = new Point((movedObject.Location.X - lastLocation.X) + e.X, (movedObject.Location.Y - lastLocation.Y) + e.Y);
                    movedObject.Update();
                }
            };
            control.MouseUp += (o, e) => { mouseDown = false; };
        }
    
        #endregion
    }
