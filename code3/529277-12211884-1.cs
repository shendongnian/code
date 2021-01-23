    public bool PlaceBet(int Amount, int Dog)
    {
        this.MyBet = new Bet();
        if (Cash >= Amount)
        {
            Cash = Cash - Amount;
            // remove the following line
            // MyLabel = new Label();
            MyBet.Amount = Amount;
            MyBet.Dog = Dog;
            // insert this line...
            MyBet.Bettor = this;
            UpdateLabels();
            return true;
        }
        else
        {
            return false;
        }
    }
