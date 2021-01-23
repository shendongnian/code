    namespace WpfApplication4
    {
      /// <summary>
      /// Interaction logic for App.xaml
      /// </summary>
      public partial class App : Application
      {
          public static string[] mArgs;
          private void App_OnStartup(object sender, StartupEventArgs e)
          {
              if (e.Args.Length > 0)
              {
                  mArgs = e.Args;
              }
          }
        }
    }
