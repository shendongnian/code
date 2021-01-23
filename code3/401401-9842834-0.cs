        List<Card> cardList = new List<Card>();
        cardList.Add(new Card { Suit = SUITS.Diamonds, Val = RANK.Two });
        cardList.Add(new Card { Suit = SUITS.Hearts, Val = RANK.Three });
        cardList.Add(new Card { Suit = SUITS.Clubs, Val = RANK.Five });
        cardList.Add(new Card { Suit = SUITS.Diamonds, Val = RANK.Seven });
        cardList.Add(new Card { Suit = SUITS.Hearts, Val = RANK.Four });
        cardList.Add(new Card { Suit = SUITS.Clubs, Val = RANK.King });
        cardList.Add(new Card { Suit = SUITS.Diamonds, Val = RANK.Ace });
        int card = 0;
        foreach (Card c in cardList)
        {
            card |= 1 << (int)c.Val - 1;
        }
        bool isStraight = false;
        RANK high = RANK.Five;
        int mask = 0x1F;
        while (mask < card)
        {
            ++high;
            if ((mask & card) == mask)
            {
                isStraight = true;
            }
            else if (isStraight)
            {
                --high;
                break;
            }
            mask <<= 1;
        }
        // Check for Ace low
        if ((!isStraight) && ((0x100F & card) == 0x100F))
        {
            isStraight = true;
            high = RANK.Five;
        }
        return card;
