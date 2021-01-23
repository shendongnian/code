    Collection output = pipeline.Invoke();
    foreach (PSObject psObject in output)
    {
      Process process = (Process)psObject.BaseObject;
      Console.WriteLine("Process name: " + process.ProcessName);
    }
