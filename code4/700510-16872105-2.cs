    public class MouseDoubleClick {
    
      ...
    
      private static void OnMouseDoubleClick(object sender, RoutedEventArgs e) {
        Control control = sender as Control;
        ICommand command = (ICommand)control.GetValue(CommandProperty);
        object commandParameter = control.GetValue(CommandParameterProperty);
        command.Execute(commandParameter);
      }
    }
