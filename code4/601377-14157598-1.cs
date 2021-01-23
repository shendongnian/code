     [STAThread]
     static void Main(string[] args)
     {
         if(args.Length > 0)
         {
              
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
    
            Application.Run(new Form1());
         }
     }
