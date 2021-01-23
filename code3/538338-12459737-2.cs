    public class MessageFilter : IMessageFilter
    {
            const int WM_KEYDOWN = 0x100;
            const int WM_KEYUP = 0x101;
    
            public bool PreFilterMessage(ref Message m)
            {
                // Intercept KEY down message
                Keys keyCode = (Keys)(int)m.WParam & Keys.KeyCode;
    
                if ((m.Msg == WM_KEYDOWN)
                {
                     //get key pressed  
    
                     return true;
                }        
                else
                {
                    return false;
                }
    
             
            }
    }
