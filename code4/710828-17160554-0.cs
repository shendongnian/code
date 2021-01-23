    public Card AddCard(Card card)
        {
            var cardProxy= _db.Cards.Create(); 
            //and copy all values from card to cardProxy here..
            int parentId = 0;
            Set parentSet = null;
            if (cardProxy.ParentSetId.HasValue)
            {
                parentId = cardProxy.ParentSetId.Value;
                parentSet = GetSet(parentId);
            }
            cardProxy.ParentSet = parentSet;
            cardProxy.ParentSetId = parentSet.SetId;
    
            cardProxy.StageId = Stage.Ids.One;  // Set Id here with hopes of getting card.Stage to resolve as a nav property
    
              SaveChanges();
    
            return cardProxy;
    }
