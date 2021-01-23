    using System.Windows.Forms;
    namespace ReusingUserControlsSample
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                mykeyboard.TheOutput = mytextbox;
            }
        }
    }
