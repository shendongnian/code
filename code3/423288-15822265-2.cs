    //I use here an arbitrarily angle of 60 degrees, 30 above x-axis and 30 under it.
        //If you have the end-points of each line, all you have to do is to implement it
        //instead and do some adaptation to extend the arc properly:
        private void btnArc_Click(object sender, EventArgs e)
        {
            int startX1, startX2, endX1, endX2, startY1, startY2, endY1, endY2, LineLength;
            double angle, startAngle, sweepAngle;
            const double RADIANS_TO_DEGREES = 180.0 / Math.PI;
            const double DEGREES_TO_RADIANS = Math.PI / 180.0;
            startX1 = startX2 = 350; //Set arbitrarily as the middle of a pictureBox, can be changed to pictureBox1.Width/2
            startY1 = startY2 = 350; //Set arbitrarily as the middle of a pictureBox, can be changed to pictureBox1.Height/2
            LineLength = 100; // length of 100 pixels set arbitrarily
            angle = 30; // measured in degrees, starts counting from x-axis, hour 3 position clockwise
            endX1 = startX1 + (int)(LineLength * Math.Cos(angle * DEGREES_TO_RADIANS)); //60 is an arbitary angle of mine
            endY1 = startY1 + (int)(LineLength * Math.Sin(angle * DEGREES_TO_RADIANS));
            endX2 = startX2 + 87; // Point equal to 30 degrees from x-axis set arbitrarily for demo purposes
            endY2 = startY2 - 50;
            //following multiplied by 2 since arbitrarily angle of 30 degrees from above axis to 30 deg. under axis equals 60 degrees
            sweepAngle = 2 * RADIANS_TO_DEGREES*(Math.Asin(((double)endY1 - (double)startY1) / (double)LineLength));
            startAngle = RADIANS_TO_DEGREES*(Math.Asin(((double)endY2 - (double)startY2) / (double)LineLength));
            System.Drawing.Graphics surface3 = pictureBox1.CreateGraphics();
            Pen pen1 = new Pen(Color.Blue, 2.0f);
            Pen pen2 = new Pen(Color.Red, 1.0f);
            //Assuming the arc should be symmetrical, as you didn't mention otherwise
            //A surrounding rectangle would have length and height equal to twice the line-length
            //The surrounding rectabgle middle point would be the common starting point of your lines
            int RecX = startX1 - LineLength;
            int RecY = startY1 - LineLength;
            int RecWidth = LineLength * 2;
            int RecHeight = LineLength * 2;
            Rectangle rect3 = new Rectangle(RecX, RecY, RecWidth, RecHeight);
            surface3.SmoothingMode = SmoothingMode.AntiAlias;
            surface3.DrawLine(pen1, startX1, startY1, endX1, endY1);
            surface3.DrawLine(pen1, startX2, startY2, endX2, endY2);
            surface3.DrawRectangle(pen1, rect3);
            surface3.DrawArc(pen2, rect3, (Single)startAngle, (Single)sweepAngle);
        }
