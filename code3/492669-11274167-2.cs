    class PrintJob
    {
        public int printRepeat {get; set;}
        public string printText {get; set;}
        // If required, you could add more fields
    }
    
    List<PrintJob> printJobs = new List<PrintJob>()
    {
        new PrintJob{printRepeat = 2, printText = "Hello World"},
        new PrintJob{printRepeat = 2, printText = "Goodbye World"}
    }
    
    foreach(PrintJob p in printJobs)
        // do the work
