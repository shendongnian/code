     public Card AddCard(Card card)
            {
                int parentId = 0;
                Set parentSet = null;
                if (card.ParentSetId.HasValue)
                {
                    parentId = card.ParentSetId.Value;
                    parentSet = GetSet(parentId);
                }
        
                card.ParentSet = parentSet;
                card.ParentSetId = parentSet.SetId;
        
                card.StageId = Stage.Ids.One;  // Set Id here with hopes of getting card.Stage to resolve as a nav property
        
                _db.Cards.Add(card);
        
                SaveChanges();
        
                context.Entry(card).Reference(p => p.Stage).Load();//load stage here
               
               return card;
            }
