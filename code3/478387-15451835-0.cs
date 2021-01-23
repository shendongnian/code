     public string BuyerSequenceNumberMax(int buyerId)
        {
            string sequenceMaxQuery = "SELECT TOP(1) btitosal.BuyerSequenceNumber FROM BuyerTakenItemToSale btitosal " +
                                      "WHERE btitosal.BuyerID =  " + buyerId +
                                      "ORDER BY  CONVERT(INT,SUBSTRING(btitosal.BuyerSequenceNumber,7, LEN(btitosal.BuyerSequenceNumber))) DESC";
            var sequenceQueryResult = context.Database.SqlQuery<string>(sequenceMaxQuery);
            string buyerSequenceNumber = string.Empty;
            if (sequenceQueryResult != null)
            {
                buyerSequenceNumber = sequenceQueryResult.ToString();
            }
            return buyerSequenceNumber;
        }
