    public void ScoreBall(int pinsKnockedDown, bool first)
    {
        if (first) {
            if (IsStrike(Frame, pinsKnockedDown)) {
                Score = "X";
                ScoreMessage = "Good Job";
            } else if (IsGutterBall(pinsKnockedDown)) {
                Score = "0";
                ScoreMessage = "You'll do better next time";
            }
        }
        PinsTotal += pinsKnockedDown;
    }
