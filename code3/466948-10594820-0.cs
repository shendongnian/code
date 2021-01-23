    using (var output = File.Open(outputFile,FileMode.Append,FileAccess.Write))
          {
             foreach (var inputFile in inputFiles)
             {
               using (var input = File.OpenRead(inputFile))
               {
                   input.Position = Encoding.Unicode.GetPreamble().Length;  //The encoding might be any type.
                  input.CopyTo(output);
               }
             }
          }
