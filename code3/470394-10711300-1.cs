    public decimal CalculatePrice(PriceQuote price, StepFilingInformation filing)
    {
        return price.priceChapter7 + 
            (filing.PaymentPlanRadioButton == Models.StepFilingInformation.PaymentPlan.Yes) 
            ? price.pricePaymentPlanChapter7 : 0);
    }
