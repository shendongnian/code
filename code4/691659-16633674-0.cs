    if(args != null && args.Length > 0)
    {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Basic_Word_Processor());
                Basic_Word_Processor.Instance.richTextBoxPrintCtrl1.LoadFile(args[0].ToString());
    }
    else
    {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Basic_Word_Processor());
    }
