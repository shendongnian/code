    int startingLevel = 2; //EMR is level 1, while the entries of CustomTextBox and AllControlsCount 
                           //are at Level 2. The question wants to split on those Level 2 items 
                           //and so this parameter is set to 2.
    int numEntriesPerFile = 1;  //Question wants 1 entry per file which will result in 3 files,  
                                //each with one entry.
    
    XMLFileManager xmlFileManager = new XMLFileManager();
    List<string> resultingFilesList = xmlFileManager.SplitXMLFile("before_split.xml", startingLevel, numEntriesPerFile);
