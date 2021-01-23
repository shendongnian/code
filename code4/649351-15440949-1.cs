    class CardModel
    {
        int Score;
        SuitEnum Suit;
        CardEnum CardValue;
    }
    
    class PlayerModel 
    {
        ObservableCollection<Card> FaceUpCards;
        ObservableCollection<Card> FaceDownCards;
        int CurrentScore;
    
        bool IsBust
        {
            get
            {
                return Score > 21;
            }
        }
    }
