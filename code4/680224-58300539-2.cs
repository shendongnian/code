    using System.Windows.Input;
    public class ViewModel : ViewModelBase
    {
        readonly CommandBindingCollection commands = new CommandBindingCollection();
        
        public static RoutedUICommand ClearCommand { get; set; } = new RoutedUICommand("Clear", "ClearCommand", typeof(ErrorDialog));
    
        public CommandBindingCollection Commands
        {
            get
            {
                commands.Add(new CommandBinding(ClearCommand, OnClearExecuted);
                return commands;
            }
        }
    
        void OnClearExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            view.DialogResult = true; //Indicate things
            view.Close(); //Close the window
        }
    }
