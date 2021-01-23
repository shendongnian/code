            protected Button GetDeleteButton(Window window, string tabName){
                var tab = FindVisualChildren<RibbonTab>(window).FirstOrDefault(n => n.Name == tabName);
                if (tab == null){
                    return null;
                }
                var groups = tab.Items.Cast<object>().Where(n => n is RibbonGroup).Cast<RibbonGroup>();
    
                foreach (var group in groups){
                    var buts = group.Items.Cast<object>().Where(n => n is RibbonButton).Cast<RibbonButton>();
                    var myButton = buts.FirstOrDefault(n => (string)n.Tag == "Delete");
                    if (myButton != null){
                        return myButton;
                    }
                }
    
                return null;
            }
            public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject {
                if (depObj != null) {
                    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++) {
                        DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                        if (child != null && child is T) {
                            yield return (T)child;
                        }
    
                        foreach (T childOfChild in FindVisualChildren<T>(child)) {
                            yield return childOfChild;
                        }
                    }
                }
            }
