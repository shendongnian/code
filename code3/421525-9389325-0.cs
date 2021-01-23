            public partial class App : Application
            {
              private readonly IList<Window> _windows = new List<Window>();
              
              protected override void OnStartup(StartupEventArgs e)
              {
                base.OnStartup(e);        
                
                // Add windows you want to open here.
                foreach (var w in _windows)
                {
                  w.Show();
                }
            }
