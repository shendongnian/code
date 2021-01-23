    using System.Windows.Forms;
    public class CheckedListBoxIgnoreKeyboard : CheckedListBox
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return true;
        }
    }
