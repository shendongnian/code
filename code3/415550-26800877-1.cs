    using System.Runtime.InteropServices;
    namespace WindowsFormsControlLibrary1
    {
        [ComVisible(true)]
        [Guid("CD46781D-B691-4287-B802-C9E2540AF08A")]
        [ProgId("WpfComHostDemo.WinformHostUserControl")]
        [ClassInterface(ClassInterfaceType.AutoDispatch)]
        public partial class UserControl1 : UserControl
        {      
            public UserControl1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                MessageBox.Show(Environment.UserName+" "+Environment.MachineName+" "+
                                Environment.OSVersion);
            }
        }
    }
