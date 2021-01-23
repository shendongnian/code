    public class MyListView : ListView
    {
        //
        //some other code here, i.e. define constants, PInvoke, etc (see link)
        //
        protected override void WndProc(ref Message m)
        {
            //the link uses WM_LBUTTONDOWN but I found that it doesn't work
            if (m.Msg == WM_LBUTTONUP) 
            {
                LVHITTESTINFO info = new LVHITTESTINFO();
                //The LParamToPOINT function I adapted to not bother with 
                //  converting to System.Drawing.Point, rather I just made 
                //  its return type the POINT struct
                info.pt = LParamToPOINT(m.LParam);
    
                //if the click is on the group header, exit, otherwise send message
                if (SendMessage(this.Handle, LVM_SUBITEMHITTEST, -1, ref info) != -1)
                    if ((info.flags & LVHITTESTFLAGS.LVHT_EX_GROUP_HEADER) != 0)
                        return; //*
            }
            base.WndProc(ref m);
        }
    }
