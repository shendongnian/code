        System.IO.StreamWriter sw = new System.IO.StreamWriter(Stream.Null);
        System.IO.TextWriter tmp = Console.Out;
        Console.SetOut(sw);
        try { SINST.Install(state); }
        catch (Exception Ex) { Console.SetOut(tmp); Console.WriteLine(Ex.Message); }
        finally { Console.SetOut(tmp); }
