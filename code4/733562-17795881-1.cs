    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Form1 form = new Form1();
        Application.Run(form);
        //...
        for (int i = 0; i < 10; i++)
        {
            //...
            form.SetTextForLabel(price);
        }
        //...
    }
