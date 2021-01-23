        public void AddBill(BillDTO bill)
        {
            //Map the DTO to your entities
            var bill1 = mapper1.Map(bill);
            var bill2 = mapper2.Map(bill);
            var bill3 = mapper3.Map(bill);
            //Open the transaction
            using (var scope = db.Transaction)
            {
                // Do transacted updates here
                db.Save(bill1);
                db.Save(bill2);
                db.Save(bill3);
                // Commit
                scope.Complete();
            }
        }
