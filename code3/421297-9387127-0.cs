    void OnReceive(string data)
    {
        if(data.Equals("exit"))
        {
            connection.Stop();
            return;
        }
        Console.WriteLine(data);
    }
