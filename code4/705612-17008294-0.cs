    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public class MyTextBox : TextBox 
        {
            protected override void WndProc(ref Message m)
            {
                // Trap WM_PASTE:
                if (m.Msg == 0x302 && Clipboard.ContainsText())
                {
                    var pastText = Clipboard.GetText().Replace('\n', ' ');
                    if (pastText.Length > MaxLength)
                    {
                        //Do Something 
                    }
                    else
                    {
                        //Do Something 
                    }
                    this.SelectedText = pastText;
                    return;
                }
                base.WndProc(ref m);
            }
        }
    }
