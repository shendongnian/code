    using System.Collections.Generic;
    using System.Windows;
    
    namespace WpfApplication5
    {
        public partial class Window2 : Window
        {
            public Window2()
            {
                InitializeComponent();
    
                var list = new List<ComboBoxItem>
                    {
                        new ComboBoxItem {DisplayText = "Header1", IsHeader = true},
                        new ComboBoxItem {DisplayText = "Item1", IsHeader = false},
                        new ComboBoxItem {DisplayText = "Item2", IsHeader = false},
                        new ComboBoxItem {DisplayText = "Item3", IsHeader = false},
                        new ComboBoxItem {DisplayText = "Header2", IsHeader = true},
                        new ComboBoxItem {DisplayText = "Item4", IsHeader = false},
                        new ComboBoxItem {DisplayText = "Item5", IsHeader = false},
                        new ComboBoxItem {DisplayText = "Item6", IsHeader = false},
                    };
    
                DataContext = list;
            }
        }
    
        public class ComboBoxItem
        {
            public string DisplayText { get; set; }
            public bool IsHeader { get; set; }
        }
    }
