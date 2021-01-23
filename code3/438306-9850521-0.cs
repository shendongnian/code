    public partial class MyBootstrapper : MefBootstrapper
    {
       public MyBootstrapper()
       {
          App.Current.Exit += new ExitEventHandler(Current_Exit);
       }
    
       void Current_Exit(object sender, ExitEventArgs e)
       {
          if (this.Container != null)
             this.Container.Dispose();
       }
    ...
