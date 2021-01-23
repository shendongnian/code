    public PrintDocument Document {
                get { return printDocument;}
                set {
                    printDocument = value; 
                    **if (printDocument == null)
                        settings = new PrinterSettings();** 
                    else 
                        settings = printDocument.PrinterSettings;
                } 
            }
