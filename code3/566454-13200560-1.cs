    public class DoubleBufferedListBox : ListBox {
        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;   //WS_EX_COMPOSITED
                return cp;
            }
        } 
        
        public DoubleBufferedListBox( ) {
            //DoubleBuffered = true;
            this.SetStyle(ControlStyles.DoubleBuffered, true);         
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
    }
