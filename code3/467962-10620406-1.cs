    using System.Threading.Tasks
-
    Files.Clear(); //List<string> 
    Task.Factory.StartNew( () =>
    {
          this.BeginInvoke( new Action(() =>
             {
                Files.Add("Hi");
             }));
     });
