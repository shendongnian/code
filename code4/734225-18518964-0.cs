    using System;
    using System.Windows.Forms;
    
    public class CustomListView : ListView
    {
        private bool contextMenuAllowed = false;
    
        public override ContextMenuStrip ContextMenuStrip
        {
            get
            {
                return base.ContextMenuStrip;
            }
            set
            {
                base.ContextMenuStrip = value;
                base.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
            }
        }   
    
        public CustomListView()
        {
        }
    
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewHitTestInfo lvhti = HitTest(e.X, e.Y);
                if (lvhti.Item != null)
                {
                    contextMenuAllowed = true;
                }
            }
      
            base.OnMouseDown(e);
        }
    
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuAllowed = false;
            }
    
            base.OnMouseUp(e);
        }
        
        private void ContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!contextMenuAllowed)
                e.Cancel = true;
        }
    }
