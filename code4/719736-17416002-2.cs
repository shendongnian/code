        public class CustomTextBox : TextBox
        {
            [DllImport("user32")]
            private static extern IntPtr GetWindowDC(IntPtr hwnd);
            struct RECT
            {
              public int left, top, right, bottom;
            }
            struct NCCALSIZE_PARAMS
            {
              public RECT newWindow;
              public RECT oldWindow;
              public RECT clientWindow;
              IntPtr windowPos;
            }            
            float clientPadding = 2;  
            float actualBorderWidth = 4;
            Color borderColor = Color.Red;      
            protected override void WndProc(ref Message m)
            {
              //We have to change the clientsize to make room for borders
              //if not, the border is limited in how thick it is.
              if (m.Msg == 0x83) //WM_NCCALCSIZE   
              {
                if (m.WParam == IntPtr.Zero)
                {
                    RECT rect = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));
                    rect.left += clientPadding;
                    rect.right -= clientPadding;
                    rect.top += clientPadding;
                    rect.bottom -= clientPadding;
                    Marshal.StructureToPtr(rect, m.LParam, false);
                }
                else
                {
                    NCCALSIZE_PARAMS rects = (NCCALSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(NCCALSIZE_PARAMS));
                    rects.newWindow.left += clientPadding;
                    rects.newWindow.right -= clientPadding;
                    rects.newWindow.top += clientPadding;
                    rects.newWindow.bottom -= clientPadding;
                    Marshal.StructureToPtr(rects, m.LParam, false);
                }
              }
              if (m.Msg == 0x85) //WM_NCPAINT    
              {         
                 IntPtr wDC = GetWindowDC(Handle);
                 Graphics g = Graphics.FromHdc(wDC);                                                      
                 ControlPaint.DrawBorder(g, new Rectangle(0,0,Size.Width, Size.Height), borderColor, actualBorderWidth, ButtonBorderStyle.Solid,
                 borderColor, actualBorderWidth, ButtonBorderStyle.Solid, borderColor, actualBorderWidth, ButtonBorderStyle.Solid,
                 borderColor, actualBorderWidth, ButtonBorderStyle.Solid);                
              }
              base.WndProc(ref m);
            }
        }
