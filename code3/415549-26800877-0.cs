Hi
I think that you forgot to set some options :
 1- set register for com interop from build menu in project property page.
 2- your control's code should be something like that (do not forget Comvisible and Guid):
   
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
                MessageBox.Show(Environment.UserName+" "+Environment.MachineName+" "+Environment.OSVersion);
            }
        }
    }
3- in your html or asp.net page use this code :
    
  &lt; object classid="clsid:CD46781D-B691-4287-B802-C9E2540AF08A" /&gt;
4- put uour control dll in the root of your web site
5- there is no need to add it as a reference.
