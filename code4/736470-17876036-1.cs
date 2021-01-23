    public class CustomPanel : Panel {
        public bool ScrollDisabled { get;set;}
        protected override void WndProc(ref Message m){
           if(m.Msg == 0x20a && ScrollDisabled) return; //WM_MOUSEWHEEL = 0x20a
           //if(m.Msg == 0x20a && ModifierKeys == Keys.Control) return;  <--- or do this directly.
           base.WndProc(ref m);
        }
    }
    
