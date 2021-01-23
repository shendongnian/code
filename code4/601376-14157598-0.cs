     [STAThread]
     static void Main(string[] args)
     {
         // In winforms apps we have always at least one argument 
         // the app.exe iteself
         if(args.Length > 1)
         {
              
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
    
            Application.Run(new Form1());
         }
     }
