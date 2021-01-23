    StringBuilder outputString = new StringBuilder();
    StringBuilder errorString = new StringBuilder();
    p.OutputDataReceived += (sender, e) =>
                {
                    if (e.Data != null)
                    {
                        outputString.AppendLine("Info " + e.Data);
                    }
                };
    p.ErrorDataReceived += (sender, e) =>
                {
                    if (e.Data != null)
                    {
                        errorString.AppendLine("EEEE " + e.Data);
                    }
                };
