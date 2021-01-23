    public class GameViewModel
    {
        ObservableCollection<CardModel> Deck;
        PlayerModel Dealer;
        PlayerModel Player;
        ICommand DrawCardCommand;
    
        void DrawCard(Player currentPlayer)
        {
            var nextCard = Deck.First();
            currentPlayer.FaceUpCards.Add(nextCard);
            if (currentPlayer.IsBust)
                // Process next player turn
            Deck.Remove(nextCard);
        }
    }
