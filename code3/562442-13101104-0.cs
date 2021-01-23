    int FileSize = 0; //This belongs to the process you would like to terminate
    //Create the process csrss for every process with the name csrss
    foreach (Process csrss in Process.GetProcessesByName("csrss"))
    { 
         FileInfo csrssFile = new FileInfo(csrss.StartInfo.FileName); //Get the properties of its file name
         if (csrssFile.Length == FileSize)
         {
             csrss.Kill(); //Terminate the process based on its file length (size)
         }
             
    }
