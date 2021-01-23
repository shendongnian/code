    public static void Main()
    {
        Form form = new Form();
        Action action = New Action<Form>(AMethod);
        Task.Factory.StartNew(
            () =>
            {                    
                form.Show();                    
                form.Invoke(action, form);
                Application.Run();
            }
         );
        Console.Read();
    }
    public static void AMethod(Form form)
    {
        form.SendToBack();
    }
