    using System.Threading;
    
    namespace UICulture
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
                Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.InvariantCulture;
                InitializeComponent();
            }
        }
    }
