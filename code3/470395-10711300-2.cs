    public class Calculations
    {
        PriceQuote price = new PriceQuote();
        // private local variable - will ALWAYS have PaymentPlanRadioButton = null
        StepFilingInformation filing = new StepFilingInformation();
        public decimal Chapter7Calculation
        {
            get {
                return
                    price.priceChapter7
                    +
                    (filing.PaymentPlanRadioButton == Models.StepFilingInformation.PaymentPlan.Yes)
                    ? price.pricePaymentPlanChapter7
                    : 0);
            }
        }
    }
