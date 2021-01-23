    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public class Communication
        {
            public void CallDisplayDataMethodFromMainForm()
            {
                string message = MainFormClass.DisplayData(1, 2).ToString();
                MessageBox.Show(message);
            }
        }
        
        public partial class MainFormClass : Form
        {
            public MainFormClass()
            {
                InitializeComponent();
            }
    
            public static int DisplayData(int a, int b)
            {
                return 0;
            }
        }
    }
