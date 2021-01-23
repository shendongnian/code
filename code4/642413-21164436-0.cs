    // Store the Excel processes before opening.
    Process[] processesBefore = Process.GetProcessesByName("excel");
    // Open the file in Excel.
    Application excelApplication = new Application();
    Workbook excelWorkbook = excelApplication.Workbooks.Open(Filename);
    // Get Excel processes after opening the file.
    Process[] processesAfter = Process.GetProcessesByName("excel");
    // Now find the process id that was created, and store it.
    int processID = 0;
    foreach (Process process in processesAfter)
    {
        if (!processesBefore.Select(p => p.Id).Contains(process.Id))
        {
            processID = process.Id;
        }
    }
    // Do the Excel stuff
    // Now close the file with the COM object.
    excelWorkbook.Close();
    excelApplication.Workbooks.Close();
    excelApplication.Quit();
    // And now kill the process.
    if (processID != 0)
    {
        Process process = Process.GetProcessById(processID);
        process.Kill();
    }
