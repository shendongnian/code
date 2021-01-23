    Task[] tasks = new Task[2];
    decimal[] numbers;
    tasks[0] = Task.Factory.StartNew(() =>
       {numbers = getNumbers(bitmap, dictionary1);});
    string[] text;
    tasks[1] = Task.Factory.StartNew(() =>
       {text = getText(bitmap, dictionary2);});
    Task.WaitAll(tasks);  // Wait for all parallel tasks to finish 
                          // before using their output.
    textBox1.Text = "" + text[0];
