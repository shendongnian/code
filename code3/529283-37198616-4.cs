    public void ClearBet(bool isRaceOver)
        {
            if (isRaceOver)
            // reset bet when race is over
            {
                MyBet = null;                
            }
            else
            {
                if (this.MyBet != null)
                {
                    Cash += this.MyBet.Amount;
                    this.MyBet = null;                 
                }
                else
                {
                    this.MyBet = null;
                }                 
            }
            UpdateLabels();
        }
