    using System.Windows.Forms;
    
    namespace System.Windows.Forms
    {
        public static partial class MessageBoxCustom
        {
            public static void Show()
            {
                (new MessageBoxCustomDialog()).ShowDialog();
            }
    
            private partial class MessageBoxCustomDialog : Form
            {
    
            }
        }
    }
