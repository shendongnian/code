    var task = Task.Factory.StartNew(() =>
       {
            // setup
            // var stuff = ParseFile()
            // Executes elements in parallel and blocks this thread until all have completed, else bubbles the exception up
            var transformations = excelProcessing.Result.RowParsing.AsParallel().Select(x =>
               {
                    FillTemplate(x);
               }).ToArray();
            // create summary text file
            // Finalize
            return processingResult;
       });
