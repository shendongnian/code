    class MainWindow
    {
        startCalc()
        {
            //your code
            CalcClass calc = new CalcClass();
            calc.ProgressUpdate += (s, e) => {
                Dispatcher.Invoke((Action)delegate() { /* update UI */ });
            };
            Thread calcthread = new Thread(new ParameterizedThreadStart(calc.testMethod);
            calcthread.Start(input);
        }
    }
    
    class CalcClass
    {
        public event EventHandler ProgressUpdate;
    
        public testMethod(object input)
        {
            //part 1
            if(ProgressUpdate != null)
                ProgressUpdate(this, new YourEventArgs(status));
            //part 2
        }
    }
