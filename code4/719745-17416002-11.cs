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
          int clientPadding = 2;   
          int actualBorderWidth = 4;     
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
                using(Graphics g = Graphics.FromHdc(wDC)){                                                
                  Rectangle rect = new Rectangle(0,0,Width,Height);
                  Rectangle inner = new Rectangle(0, 0, Width, Height);
                  inner.Offset(actualBorderWidth + 2, actualBorderWidth + 2);
                  inner.Width -= 2 * actualBorderWidth + 4;
                  inner.Height -= 2 * actualBorderWidth + 4;
                  Region r = new Region(rect);
                  r.Xor(inner);
                  using (System.Drawing.Drawing2D.HatchBrush brush = new System.Drawing.Drawing2D.HatchBrush(System.Drawing.Drawing2D.HatchStyle.SmallCheckerBoard, Color.Green, Color.Red))
                  {                    
                    g.FillRegion(brush, r);
                  }
                }
                return;
              }
              base.WndProc(ref m);
          }
        }
