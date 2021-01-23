        bool started = false;
        var p = new Process();
        p.StartInfo.FileName = "notepad.exe";
        started = p.Start();
        try {
          var procId = p.Id;
          Console.WriteLine("ID: " + procId);
        }
        catch(InvalidOperationException)
        {
            started = false;
        }
        catch(Exception ex)
        {
            started = false;
        }
