     public void MigrateDataForInd(Individu from.Gifts, Individu1 to){
            foreach (var item in from.Gifts) {
                to.Gifts.Add(item);            
            }
            this.SaveChanges();
         }
