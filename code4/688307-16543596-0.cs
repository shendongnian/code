    using System.Drawing;
    using System.Windows.Forms;
    
    namespace TetrisGame
    {
        public sealed class TetrisControl : Control
        {
            private TheBlockType[][] blocks = ...;
            protected override void OnPaint(PaintEventArgs e)
            {
                //draw your stuff here direct to the control, no buffers in the middle
                //if that causes flickering, turn on double buffering, but don't bother doing it yourself
                //this is your existing draw method:
                Draw(e.Graphics);
            }
        }
    }
