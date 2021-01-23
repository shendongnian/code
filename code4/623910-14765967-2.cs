    public List<Card> Shuffle(List<Card> cardDeck)
    {
        int index = 0;
        List<Card> tempDeck = new List<Card>();
        List<Card> localCopy = new List<Card>(cardDeck);   //Creates a shallow copy of the list.      
        while (localCopy.Count > 0)
        {
            int removal = randomCard.Next(0, cardDeck.Count);
            Card tempCard = localCopy.RemoveAt(removal);
            tempDeck.Add(tempCard);
        }
        return tempDeck;
    }
