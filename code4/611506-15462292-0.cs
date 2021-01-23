    public BuyerInformation Update(BuyerInformation objBuyerInformation)
        {
            context.BuyerInformation.Attach(objBuyerInformation);
            context.Entry(objBuyerInformation).State = EntityState.Modified;
            context.SaveChanges();
            return objBuyerInformation;
        }
