    using System.Windows;
    using BaseFramework.MVVM;
    using System.Collections.ObjectModel;
    namespace WpfApplication4
    {
        public partial class Window12 : Window
        {
            public Window12()
            {
                InitializeComponent();
                DataContext = new TabbedViewModel()
                              {
                                  Items =
                                      {
                                          new TabViewModel() {Title = "Tab #1", IsEnabled = true, IsVisible = true},
                                          new TabViewModel() {Title = "Tab #2", IsEnabled = false, IsVisible = true},
                                          new TabViewModel() {Title = "Tab #3", IsEnabled = true, IsVisible = false},
                                      }
                              };
            }
        }
