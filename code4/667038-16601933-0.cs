    void Form1_Paint(object sender, PaintEventArgs e)
            {
                float[] dashValues = { 8, 5, 2, 4 };
                Pen blackPen = new Pen(Color.Black, 5);
                blackPen.DashPattern = dashValues;
                blackPen.Width = 3;
                //blackPen.StartCap=LineCap.Round
                blackPen.StartCap =LineCap.Flat;
                //blackPen.StartCap=LineCap.Round
                blackPen.EndCap = LineCap.Flat;
                e.Graphics.DrawLine(blackPen, new Point(85, 95), new Point(405, 95));
                            
            }
