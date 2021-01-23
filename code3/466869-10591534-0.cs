    private Random random;
    private void buttonStartPlay_Click(object sender, RoutedEventArgs e) 
    {        
        random = new Random((int) DateTime.Now.Ticks);  
    }  
    private void buttonHumanGuess_Click(object sender, RoutedEventArgs e) 
    {        
        if(IsAnswerCorrect(//HumanGuess))
             //Human Wins
        else
            ComputerGuess();
    }  
    private int ComputerGuess()
    {
        //Do something to get computer answer
        if(IsAnswerCorrect(//ComputerGuess))
             //Computer Wins
    }
    private bool IsAnswerCorrect(int answer)
    {
        if(answer == random.YourStoredValue)
            return true;
        else
            return false;
    }
