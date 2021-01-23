    namespace System.Windows.Forms
    {
        // make sure this is the first class in the file (required by designer)
        public partial class MessageBoxCustomDialog : Form
        {
            public MessageBoxCustomDialog()
            {
                InitializeComponent();
            }
        }
    
        public static partial class MessageBoxCustom
        {
            public static void Show()
            {
                new MessageBoxCustomDialog().ShowDialog();
            }
            // put the MessageBoxCustomDialog class here when you are done
        }
    }
