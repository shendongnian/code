    String[] content = File.ReadAllLines(jobsProcessed);
    
    String[] newContent = new String[3];
    newContent[0] = DateTime.Now.ToString();
    newContent[1] = info;  
    newContent[2] = "------";
    File.AppendAllLines(jobsProcessed, newContent);
