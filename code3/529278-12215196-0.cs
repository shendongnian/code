    public bool PlaceBet(int Amount, int Dog)
            {
                this.MyBet = new Bet();
    
                if (Cash >= Amount)
                {
                    Cash = Cash - Amount;
                    MyLabel = new Label(); // remove this
                    MyBet.Amount = Amount;
                    MyBet.Dog = Dog;
                    UpdateLabels();
                    return true;
                }
                else
                {
                    return false;
                }
            }
