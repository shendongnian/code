    timer = new Timer();
    timer.Tick += new EventHandler(timer_Tick);
    timer.Interval = 1; //set interval on 1 milliseconds
    timer.Enabled = true; //start the timer
    Result result = new Result();
    result = new GeneticAlgorithms().TabuSearch(parametersTabu, functia);
    timer.Enabled = false; //stop the timer
    private void timer_Tick(object sender, EventArgs e)
    {
       counter++;
       btnTabuSearch.Text = counter.ToString();
    }
