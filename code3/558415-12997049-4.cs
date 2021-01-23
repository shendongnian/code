    cmd.Connection.InfoMessage += Connection_InfoMessage;
    static void Connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
    {
        Console.WriteLine(e.Message);
    }
