     public partial class CustomControlForTabPage : UserControl
     {
         public CustomControlForTabPage()
         {
             InitializeComponent();
         }
     }
    //Create CustomControl
    TabPage tp = new TabPage();
    CustomControlForTabPage ccftp = new CustomControlForTabPage();
    //set properties you like for your custom control
    tp.Controls.Add(ccftp);
    tabControl1.TabPages.Add(ctp);
