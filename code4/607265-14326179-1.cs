    string pdfPath = @"C:\example.pdf";
    
    if (System.IO.File.Exists(pdfPath))
    {
         System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
         myProcess.StartInfo.FileName = "AcroRd32.exe";
         myProcess.StartInfo.Arguments = string.Format("/A \"page=2=OpenActions\" \"{0}\"", pdfPath);
         myProcess.Start();
    }
