      printProcess = new Process[noOfCopies];
      // Print number of copies specified in configuration file
      Parallel.For(0, noOfCopies, i =>
      {
        printProcess[i] = new Process();
        // Set the process information
        printProcess[i].StartInfo = new ProcessStartInfo()
        {
          CreateNoWindow = true,
          Verb = "Print",
          FileName = pdfFilePath,
          ErrorDialog = false,
          WindowStyle = ProcessWindowStyle.Hidden,
          UseShellExecute = true,
        };
        // Start the printing process and wait for exit for 7 seconds
        printProcess[i].Start();
        // printProcess[counter].WaitForInputIdle(waitTimeForPrintOut);
        printProcess[counter].WaitForExit(waitTimeForPrintOut); //<--**This is line for discussion**
        if(!printProcess[i].HasExited)
        {
          printProcess[i].Kill();
        }
      });
      // Delete the file before showing any message for security reason
      File.Delete(pdfFilePath);
