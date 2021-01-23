    public decimal decPaymentPlan(QuoteData quoteData, Chapter chapter)
    {
        if (quoteData.StepFilingInformation.PaymentPlanRadioButton 
            == StepFilingInformation.PaymentPlan.No)
            return PriceQuote.priceNoPaymentPlan;
        else
            return chapter.PaymentPlan;
    }
    public decimal Calculate(QuoteData quoteData, Chapter chapter)
    {
        decimal total = chapter.Price;
        total += this.decPaymentPlan(quoteData, chapter);
        return total;
    }
    
