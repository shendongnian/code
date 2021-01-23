    public partial class App : Application
        {
            protected override void OnStartup(StartupEventArgs e)
            {
                EventManager.RegisterClassHandler(typeof(Window), Window.PreviewMouseDownEvent, new MouseButtonEventHandler(OnPreviewMouseDown));
    
                base.OnStartup(e);
            }
    
            static void OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
            {
                Trace.WriteLine("Clicked!!");
            }
        }
