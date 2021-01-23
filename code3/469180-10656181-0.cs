      public Form1()
           {
               InitializeComponent();
           }
           protected override void OnLoad(EventArgs e)
           {
               base.OnLoad(e);
               var a = new A();
               throw new Exception();
           }
       }
