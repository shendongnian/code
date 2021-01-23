    public abstract class ViewBase : UserControl
    {
        public ViewBase()
        {
            this.KeyUp += ViewBase_KeyUp;
            this.GotFocus += ViewBase_GotFocus;
        }
        void ViewBase_GotFocus(object sender, RoutedEventArgs e)
        {
            FocusManager.SetIsFocusScope(this, true);
        }
        void ViewBase_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                var viewModel = this.DataContext as ViewModelBase;
                if (viewModel != null)
                {
                    var helpTopic = "Index";
                    var focusedElement = 
                        FocusManager.GetFocusedElement(this) as FrameworkElement;
                    if (focusedElement != null)
                    {
                        var keyword = ContextHelp.GetKeyword(focusedElement);
                        if (!String.IsNullOrWhiteSpace(keyword))
                        {
                            helpTopic = keyword;
                        }
                    }
                    viewModel.HelpCommand.Execute(helpTopic);
                }
            }
        }
    }
