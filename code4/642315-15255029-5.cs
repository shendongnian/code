       public partial class Window14 : Window
        {
            public Window14()
            {
                InitializeComponent();
    
                DataContext = new ListBoxSampleViewModel()
                                  {
                                      LeftItems =
                                          {
                                              new ListItemViewModel(){DisplayName = "Item1"},
                                              new BoolListItemViewModel() {DisplayName = "Check Item 2", Value = true},
                                              new SelectableListItemViewModel()
                                                  {
                                                      ItemsSource =
                                                          {
                                                              new ListItemViewModel() {DisplayName = "Combo Item 1"},
                                                              new BoolListItemViewModel() {DisplayName = "Check inside Combo"},
                                                              new SelectableListItemViewModel()
                                                                  {
                                                                      ItemsSource =
                                                                          {
                                                                              new ListItemViewModel() {DisplayName = "Wow, this is awesome"},
                                                                              new BoolListItemViewModel() {DisplayName = "Another CheckBox"}
                                                                          }
                                                                  }
                                                          }
                                                  }
                                          }
                                  };
            }
        }
