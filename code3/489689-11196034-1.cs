    void LineMover_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            var pen = new Pen(Color.Black, 2);
            e.Graphics.DrawLine(pen, Lines[0].StartPoint, Lines[0].EndPoint);
            e.Graphics.DrawLine(pen, Lines[0].EndPoint, Lines[1].StartPoint);
            e.Graphics.DrawLine(pen, Lines[1].StartPoint, Lines[1].EndPoint);
    }
