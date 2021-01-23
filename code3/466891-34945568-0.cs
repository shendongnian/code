    protected Button GetDeleteButton(Window window, string tabName){
                var tab = FormHelper.FindVisualChildren<RibbonTab>(window).FirstOrDefault(n => n.Name == tabName);
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
