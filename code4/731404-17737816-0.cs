    public class MyTextBox : TextBox
    {
        int maxLine = 2;
        int maxChars = 10;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x302)//WM_PASTE
            {
                string s = Clipboard.GetText();
                string[] lines = s.Split('\n');
                s = "";
                int i = 0;
                foreach (string line in lines)
                {
                    s += (line.Length > maxChars ? line.Substring(0, maxChars) : line) + "\r\n";
                    if (++i == maxLine) break;
                }
                if(i > 0) SelectedText = s.Substring(0,s.Length - 2);//strip off the last \r\n
                return;
            }
            base.WndProc(ref m);            
        }
    }
