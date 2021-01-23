    const int WM_KEYDOWN = 0x100;
    const int WM_SYSKEYDOWN = 0x104;
       
    if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
    {
       switch(keyData)
          {
             case Keys.Down:
                Console.WriteLine("Down Arrow Captured");
                break;
          
             case Keys.Up:
                Console.WriteLine("Up Arrow Captured");
                break;
     
             case Keys.Tab:
                Console.WriteLine("Tab Key Captured");
                break;
     
             case Keys.Control | Keys.M:
                Console.WriteLine("<CTRL> + m Captured");
                break;
     
             case Keys.Alt | Keys.Z:
                Console.WriteLine("<ALT> + z Captured");
                break;
          }
    }
