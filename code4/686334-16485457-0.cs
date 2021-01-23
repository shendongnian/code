    int iTemp = i;
    tasks[i] = Task.Factory.StartNew(() => {
            ProcessingTask.run(
                                 iTemp,
                                 stack,
                                 collector,
                                 sets,
                                 cts.Token,
                                 LOG
                                );
         },
         cts.Token,
         TaskCreationOptions.LongRunning,
         TaskScheduler.Default
        );
