    public void DisplayHand(bool shortFormat, bool displaySuit) {
        StringBuilder cardOutput = new StringBuilder();
        foreach (Card card in cards) {
            if (cardOutput.Length > 0) {
                // we already have one or more cards to display for this hand; separate them
                // with a space-delimiter
                cardOutput.Append(" ");
            }
            // add the current card to the display
            cardOutput.Append(card.ToString(shortFormat, displaySuit));
        }
        Console.WriteLine(cardOutput.ToString());
    }
