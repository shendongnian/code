    /* Print a document  */
    
    // Load a local sample file from the input folder
    
    DPL.LoadFromFile("Test.pdf", "");
    
    // Configure print options
    
    iPrintOptions = DPL.PrintOptions(0, 0, "Printing Sample")
    
    // Print the current document to the default 
    // printing using the options as configured above.
    // You can also specify the specific printer.
    
    DPL.PrintDocument(DPL.GetDefaultPrinterName(), 1, 1, iPrintOptions);
