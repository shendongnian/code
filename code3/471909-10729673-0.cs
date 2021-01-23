    private Bitmap _bitMap;
    private Graphics _graphic;
    Pen myPen;
    public Constructor()
    {
        _bitMap = new Bitmap(pictureBox1.Width,pictureBox1.Height);
        _graphic = Graphics.FromImage(_bitMap);
        pictureBox1.Image = _bitMap;
        myPen = new Pen(Color.Black);
    }
    private void pictureBox1_Paint_1(object sender, PaintEventArgs e)
    {
        int jobIndex = 0;
        int trussIndex = 0;
        foreach (Member m in jobArray[jobIndex].trusses[trussIndex].members)
        {
            //Pen myPen = new Pen(Color.Black); //Don't instantiate in a loop
            SolidBrush myBrush = new SolidBrush(m.color);
            _graphic.DrawPolygon(myPen, m.poly.Points.ToArray());
            _graphic.FillPolygon(myBrush, m.poly.Points.ToArray());
        }
        pictureBox1.Image = _bitMap; //Don't think you need this, but I don't remember
    }
