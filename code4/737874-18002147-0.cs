        var connector = OT.ConnectTo("(local)", "TestOTLab");
        Console.WriteLine(connector.ConnectionStatus.ToString());
        if (connector.ConnectionStatus == ConnectionStat.Fail)
        {
            Console.WriteLine(connector.ErrorMessage.ToString());
        }
