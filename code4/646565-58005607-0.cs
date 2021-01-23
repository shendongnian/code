    // extracting all the text 
    WordsTextExtractor extractor = new WordsTextExtractor("sample.docx");
    Console.Write(extractor.ExtractAll());
    
    // OR
    
    // Extract text line by line
    string line = extractor.ExtractLine();
    
    // If the line is null, then the end of the file is reached
    while (line != null)
    {
          // Print a line to the console
          Console.Write(line);
          // Extract another line
          line = extractor.ExtractLine();
    }
