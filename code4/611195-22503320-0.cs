         public partial class UCTransparent : UserControl
         {
             public UCTransparent()
             {
                    InitializeComponent(); 
             }
             protected override CreateParams CreateParams
             {
                    get
                    {
                           CreateParams cp = base.CreateParams;
                           cp.ExStyle |= 0x20;
                           return cp;
                    }
             }
             protected override void OnPaintBackground(PaintEventArgs e)
             {
                 base.OnPaintBackground(e);
             }
          }
