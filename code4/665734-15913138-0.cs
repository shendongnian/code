    private void ChangeTabColor(Object sender, DrawItemEventArgs e)
    {
        Font TabFont;
        Brush BackBrush;// = new SolidBrush(Color.Green); //Set background color
        Brush ForeBrush = new SolidBrush(Color.Black);//Set foreground color
        Brush borderBrush = new SolidBrush(Color.Black);//Set foreground color
        if (e.Index == this.tabMain.SelectedIndex)
        {
            TabFont = new Font(e.Font, FontStyle.Bold);
            BackBrush = new SolidBrush(Color.MediumSeaGreen); //Set background color
            //ForeBrush = new SolidBrush(Color.Black);//Set foreground color
        }
        else
        {
            TabFont = e.Font;
            BackBrush = new SolidBrush(Color.LightSteelBlue); //Set background color
            //ForeBrush = new SolidBrush(Color.Yellow);//Set foreground color
        }
        string TabName = this.tabMain.TabPages[e.Index].Text;
        StringFormat sf = new StringFormat();
        sf.Alignment = StringAlignment.Center;
        Rectangle r = e.Bounds;
        r = new Rectangle(r.X, r.Y + 5, r.Width, r.Height - 3);
        if (e.Index == this.tabMain.SelectedIndex)
        {
            Pen rectPen = new Pen(borderBrush, 1.0f);
            r.Y -= 2;
            r.X += 3;
            r.Height -= 9;
            r.Width -= 8;
            e.Graphics.FillRectangle(BackBrush, r);
            e.Graphics.DrawString(TabName, TabFont, ForeBrush, r, sf);
            e.Graphics.DrawRectangle(rectPen, r);
        }
        else
        {
            Pen rectPen = new Pen(borderBrush, 1.0f);
            r.Y -= 2;
            r.Height -= 4;
            r.Width -= 2;
            e.Graphics.FillRectangle(BackBrush, r);
            e.Graphics.DrawString(TabName, TabFont, ForeBrush, r, sf);
            e.Graphics.DrawRectangle(rectPen, r);
        }
        //Dispose objects
        sf.Dispose();
        if (e.Index == this.tabMain.SelectedIndex)
        {
            TabFont.Dispose();
            BackBrush.Dispose();
        }
        else
        {
            BackBrush.Dispose();
            ForeBrush.Dispose();
        }
    }
