    private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true; // If This Event Is Occured So This Variable Is True.
            LocationXY = e.Location; // Get The Starting Location Of Point X and Y.
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true) // This Block Is Not Execute Until Mouse Down Event Is Not a Fire.
            {
                LocationX1Y1 = e.Location; // Get The Current Location Of Point X and Y.
                Refresh(); // Refresh the form.
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if(IsMouseDown == true) // This Block Is Not Execute Until Mouse Down Event Is Not a Fire.
            {
                LocationX1Y1 = e.Location; // Get The Ending Point of X and Y.
                IsMouseDown = false; // false this..
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (rect != null) // Check If Rectangle Is Not a null.
            {
                e.Graphics.DrawRectangle(Pens.Red, GetRect()); // GetRect() Is a Function, Now Creates this function.
            }
        }
        private Rectangle GetRect()
        {
        //Create Object Of rect. we define rect at TOP.
            rect = new Rectangle();
        //The x-value of our Rectangle should be the minimum between the start x-value and the current x-position.
            rect.X = Math.Min(LocationXY.X, LocationX1Y1.X);
        //same as above x-value. The y-value of our Rectangle should be the minimum between the start y-value and the current y-position.
            rect.Y = Math.Min(LocationXY.Y, LocationX1Y1.Y);
         //the width of our rectangle should be the maximum between the start x-position and current x-position MINUS.
            rect.Width = Math.Abs(LocationXY.X - LocationX1Y1.X); 
            rect.Height = Math.Abs(LocationXY.Y - LocationX1Y1.Y);
            return rect;
        }
