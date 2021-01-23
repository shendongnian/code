    public Players PlayerCards()
        {   
            Players p1;
            generatedCard = randomCard.Next(1, 52);
            p1.Player1 = generatedCard.ToString();
            p1.Player2 =  p1.Player1 + ".png";            
            return p1;
        }
