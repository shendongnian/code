     public partial class TonyRush : Window
        {
            public TonyRush()
            {
                InitializeComponent();
                DataContext = new List<ScreenRequest>
                                  {
                                      new ScreenRequest() {ActionDescription = "Click Me!"},
                                      new ScreenRequest() {ActionDescription = "Click Me Too!"},
                                      new ScreenRequest() {ActionDescription = "Click Me Again!!"},
                                  };
            }
        }
