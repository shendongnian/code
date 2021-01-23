    public Outcome MakeGuess(int guess)
    {
        if (_guesses.Contains(guess)) {
            return outcome.PreviousGuess;
        }
        if (guess == Number) {
            return Outcome.Correct;
        }   
        if (guess > Number) {
            return Outcome.High;   
        }   
        return Outcome.Low;             }
    }
