    class Keypad : UserControl
    {
         ...
         public DependencyProperty OnKeypadKeyClickedCommandProperty = ... ;
         ...
         void OnZeroButtonClicked(object sender, RoutedEventArgs e)
         {
             OnKeypadKeyClickedCommand.Execute(this, new SomeKeyIdentifier('0'));
         }
         ...
    }
