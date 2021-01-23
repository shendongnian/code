    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            EventManager.RegisterClassHandler(typeof(UIElement),
                Keyboard.GotKeyboardFocusEvent,
                new RoutedEventHandler(Keyboard_GotKeyboardFocus), true);
            
            base.OnStartup(e);
        }
        private void Keyboard_GotKeyboardFocus(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(e.OriginalSource);
        }
    }
