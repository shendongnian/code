    public Form1() {
         InitializeComponent();
         toolTip1.OwnerDraw = true;
         toolTip1.Draw += new DrawToolTipEventHandler(toolTip1_Draw);          
     }
