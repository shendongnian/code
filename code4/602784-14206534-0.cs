    const int WM_LBUTTONDOWN = 0x201;
    switch( message.Msg ) 
    {
        case WM_LBUTTONDOWN:
            Int16 x = (Int16)message.LParam;
            Int16 y = (Int16)((int)message.LParam >> 16);
            //Getting the control at the correct position
            Control control = m_TableControl.GetControlFromPosition(0, (y / 16));
            if (control != null)
                m_TableControl.Refresh();
            TreeNode node = this.GetNodeAt(x, y);
            this.SelectedNode = node;
            break;
    }
