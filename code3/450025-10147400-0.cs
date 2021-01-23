    public partial class UserControl1 : UserControl
    {
         private Metafile metafile1;
         public UserControl1()
         {
             InitializeComponent();
             metafile1 = new Metafile(@"C:\logo2.emf");
         }
         protected override void OnPaint(PaintEventArgs e)
         {
             e.Graphics.DrawImage(metafile1, 0, 0);
         }
    }
