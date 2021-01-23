    Image toolTipImage = Image.FromFile(filepath);        
    if (toolTipImage != null)
        {
            myImageRectangle.Width = 200;
            myTextRectangle = new Rectangle(myImageRectangle.Right, myImageRectangle.Top, (myToolTipRectangle.Width - myImageRectangle.Right), myImageRectangle.Height);
            myTextRectangle.Location = new Point(myImageRectangle.Right, myImageRectangle.Top);
            e.Graphics.FillRectangle(myBackColorBrush, myTextRectangle);
            e.Graphics.DrawImage(toolTipImage, myImageRectangle);
            e.Graphics.DrawString(e.ToolTipText, myFont, 
			myTextBrush, myTextRectangle, myTextFormat);
        }
