    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace MyNameSpace //Make sure this matches your projects namespace
    {
        class Tools
        {
            //Because this is outside the form that is calling it, you cannot access
            //the actual form or panel where you wish to place the button(PictureBox)
            //so instead of returning void (which is nothing) we return the newly
            //created Button(PictureBox)
    
            public static PictureBox NewBtn(string nName, int locX, int locY)
            {
                Font btnFont = new Font("Tahoma", 16);
                PictureBox S = new PictureBox();
                //You need to specify a size for your pictureBox
                S.Width=100;
                S.Height=100;
                S.Location = new System.Drawing.Point(locX, locY);
                S.Paint += new PaintEventHandler((sender, e) =>
                {
                    var size = g.MeasureString(Name, btnFont);
                    e.Graphics.DrawString(Name, btnFont, Brushes.Black,
                      (S.Width - size.Width) / 2,
                      (S.Height - size.Height) / 2));
                }
                return S;
             }
        }
    }
