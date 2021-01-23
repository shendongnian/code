    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System;
    using System.Text;
    using System.Drawing;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    namespace Winform_menu
    {
      internal class NewsTicker : Panel
      {
         private Timer mScroller; // Scroll timer
         private int mOffset; // Offset of scrolled text
       private string mText; // Text to scroll
    private Size mPixels; // Width of text in pixels
    private Bitmap mBuffer; // Double-buffering buffer
    public NewsTicker()
    {
      mScroller = new Timer();
      mScroller.Interval = 30;
      mScroller.Enabled = false;
      mScroller.Tick += DoScroll;
    }
    [Browsable(true)]
    public override string Text
    {
      get { return mText; }
      set
      {
        mText = value;
        mScroller.Enabled = mText.Length > 0;
        mPixels = TextRenderer.MeasureText(mText, this.Font);
        mOffset = this.Width;
      }
    }
    private void DoScroll(object sender, EventArgs e)
    {
      // Adjust offset and paint
      mOffset -= 1;
      if (mOffset < -mPixels.Width) mOffset = this.Width;
      Invalidate();
    }
    protected override void OnPaintBackground(PaintEventArgs e)
    {
      // Do nothing
    }
    protected override void OnPaint(PaintEventArgs e)
    {
      if (mBuffer == null || mBuffer.Width != this.Width || mBuffer.Height != this.Height)
        mBuffer = new Bitmap(this.Width, this.Height);
      Graphics gr = Graphics.FromImage(mBuffer);
      Brush bbr = new SolidBrush(this.BackColor);
      Brush fbr = new SolidBrush(this.ForeColor);
      gr.FillRectangle(bbr, new Rectangle(0, 0, this.Width, this.Height));
      gr.DrawString(mText, this.Font, fbr, mOffset, 0);
      e.Graphics.DrawImage(mBuffer, 0, 0);
      bbr.Dispose();
      fbr.Dispose();
      gr.Dispose();
         }
        }
     }
