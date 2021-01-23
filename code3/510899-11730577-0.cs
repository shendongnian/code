    public class ImageButton : Button
        {
            public ImageButton()
            {
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                this.SetStyle(ControlStyles.UserPaint, true);
            }
    
            protected override void OnPaint(PaintEventArgs pevent)
            {
                //base.OnPaint(pevent); <-- NO LONGER NEEDED (WE DO NOT WANT THE SYSTEM TO PAINT THE BUTTON);
                if (this.BackgroundImage != null)
                {
                    pevent.Graphics.DrawImage(this.BackgroundImage, 0, 0);
                }
                else
                {
                    //Just fill in black (for example)
                    pevent.Graphics.FillRectangle(new SolidBrush(Color.Black), this.ClientRectangle);
                }
            }
    
            protected override void OnPaintBackground(PaintEventArgs pevent)
            {
                base.OnPaintBackground(pevent);
                pevent.Graphics.FillRectangle(new SolidBrush(this.BackColor), this.ClientRectangle);
            }
    
            public override Image BackgroundImage
            {
                get
                {
                    return base.BackgroundImage;
                }
                set
                {
                    base.BackgroundImage = value;
                    this.Size = base.BackgroundImage.Size;
                    this.Refresh();
                }
            }
        } 
