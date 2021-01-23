                if (Cash >= Amount)
                {
                    Cash = Cash - Amount;
                    MyLabel = new Label();
                    MyBet.Amount = Amount; // HERE
                    MyBet.Dog = Dog; // HERE
                    UpdateLabels();
                    return true;
