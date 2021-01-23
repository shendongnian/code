    bool openSuccessful = false;
    while (!openSuccessful)
    {
        try
        {
            using (var writer = new StreamWriter(masterlog, true)) // append
            {
                // successfully opened file
                openSuccessful = true;
                try
                {
                    foreach (var line in File.ReadLines(individualLogFile))
                    {
                        writer.WriteLine(line);
                    }
                }
                catch (exceptions that occur while writing)
                {
                    // something unexpected happened.
                    // handle the error and exit the loop.
                    break;
                }
            }
        }
        catch (exceptions that occur when trying to open the file)
        {
            // couldn't open the file.
            // If the exception is because it's opened in another process,
            // then delay and retry.
            // Otherwise exit.
            Sleep(1000);
        }
    }
    if (!openSuccessful)
    {
        // notify of error
    }
