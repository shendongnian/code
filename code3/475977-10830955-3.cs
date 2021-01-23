    Parallel.ForEach(blockingCollection1.GetConsumingPartitioner(),
                     data => {
                              var processedData = ProcessData(data);
                              blockingCollection2.Add(processedData);
                     });
