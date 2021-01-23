    namespace sampleLogin
    {
        public enum FilterClass
        {
            TypeAFilter = 1,
            TypeBFilter = 2,
            TypeCFilter = 3
        };
    
        public partial class frmLogin : Form
        {
          public frmLogin()
          {
            InitializeComponent();
            foreach (FilterClass fltClass in Enum.GetValues(typeof(FilterClass)))
            {
                Console.WriteLine(fltClass.ToString());
            }
        }
     } 
