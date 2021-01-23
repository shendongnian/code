    var tasks = new Task[10];
    for (int i = 0; i < 10; i++)
    {
        tasks[i] = Task.Factory.StartNew(() =>
        {    
            int messages_sent_by_one_task = 0;           
            while(messages_sent_by_one_task < 10)
            {
                QuickSend();
                messages_sent_by_one_task++;
            }
        });
    }
    while (tasks.Any(t => !t.IsCompleted)) { } //wait for tasks to complete
