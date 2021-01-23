     public void MigrateDataForInd(Individu from, Individu to){
            var offlineGifts = from.Gifts.ToList();
            foreach (var offlineGift in offlineGifts ) {
                from.Gifts.DeleteObject(offlineGift );
                to.Gifts.Add(offlineGift );
            }
            this.SaveChanges();
         }
