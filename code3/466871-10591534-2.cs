    private int numberToGuess = 0;
    private void buttonStartPlay_Click(object sender, RoutedEventArgs e) 
    {        
        numberToGuess = //Create Random Int;
    }  
    private void buttonHumanGuess_Click(object sender, RoutedEventArgs e) 
    {        
        if(IsAnswerCorrect(//HumanGuess))
             //Human Wins
        else
            ComputerGuess();
            //Or
            MoveToNextPlayer();
    }  
    private void MoveToNextPlayer()
    {
        //Do something to figure out who the next player is
    }
    private int ComputerGuess()
    {
        //Do something to get computer answer
        if(IsAnswerCorrect(//ComputerGuess))
             //Computer Wins
    }
    private bool IsAnswerCorrect(int answer)
    {
        if(answer == numberToGuess)
            return true;
        else
            return false;
    }
