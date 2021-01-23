    using ClassLibrary2;
    
    namespace WindowsFormsApplication20
    {
      public partial class Form1 : Form
      {
         public Form1()
         {
            InitializeComponent();
         }
    
         private Dictionary<string, Class1.Cs> Dic
         {
            get;
            set;
         }
    
         private void button1_Click(object sender, EventArgs e)
         {
            ClassLibrary2.Class1 css = new ClassLibrary2.Class1();
            Dic = css.Dic;
         }
     }
