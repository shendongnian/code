    private void Panel1_Paint(object sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        /*string rand = getRandomString();
        textBox1.Text = rand;*/
        string rand = "Hello";
        using (var sbr = new SolidBrush(Color.Black))
        { 
            FontFamily fam = new FontFamily("Magneto");
            Font font = new System.Drawing.Font(fam, 24, FontStyle.Bold);
            g.DrawString(rand, font, sbr, new Point(20, 20));
        }
    } 
