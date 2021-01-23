    using System.Windows.Forms; 
    class Form1 : Form {
        protected void EnsureVisible() {
            foreach (Screen scrn in Screen.AllScreens) {
            // You may prefer Intersects(), rather than Contains()
                if (scrn.Bounds.Contains(this.Bounds)) {
                  return;
                }
            }
            this.Location = new Point( 0, 0 );
        }
    } 
