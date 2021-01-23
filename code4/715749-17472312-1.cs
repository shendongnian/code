          public void MigrateDataForInd(Individu from, Individu to)
            {
                var offlineGifts = from.Gifts.ToList();
                foreach (var item in offlineGifts)
                {
                    from.Gifts.Remove(item);
                    to.Gifts.Add(item);
                }
                this.Save();
            }
