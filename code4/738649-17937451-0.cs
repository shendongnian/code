    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_VSCROLL || m.Msg == WM_HSCROLL || m.Msg == WM_MOUSEWHEEL)//WM_MOUSEWHEEL = 0x20a
        {
            foreach (RichTextBoxSynchronizedScroll peer in this.peers)
            {
                Message peerMessage = Message.Create(peer.Handle, m.Msg, m.WParam, m.LParam);
                DefWndProc(ref peerMessage);
            }
        }
        base.WndProc(ref m);
    }
    
    
    
