    public decimal CalculatePrice(QuoteData quoteData)
    {
        return PriceQuote.PriceChapter7 + 
            (quoteData.StepFilingInformation.PaymentPlanRadioButton == Models.StepFilingInformation.PaymentPlan.Yes) 
            ? PriceQuote.PricePaymentPlanChapter7 : 0);
    }
