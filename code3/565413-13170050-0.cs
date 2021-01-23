    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace ClassLibrary1
    {
        public class MyListBox : System.Windows.Forms.ListBox
        {
            private bool mShowScroll;
            protected override System.Windows.Forms.CreateParams CreateParams
            {
                get
                {
                    CreateParams cp = base.CreateParams;
                    if (!mShowScroll)
                        cp.Style = cp.Style & ~0x200000;
                    return cp;
                }
            }
            public bool ShowScrollbar
            {
                get { return mShowScroll; }
                set
                {
                    if (value == mShowScroll)
                        return;
                    mShowScroll = value;
                    if (Handle != IntPtr.Zero)
                        RecreateHandle();
                }
            }
        }    
    }
        
