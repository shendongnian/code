       public async Task DoSomeThing() {
           
           var Task[] tasks = new Task[numTasks];
           for(int i = 0; i < numTask; i++)
           {
              tasks[i] = CallSomeAsync();
           }
           await Task.WhenAll(tasks);
           // code that'll execute on UI thread
       }
