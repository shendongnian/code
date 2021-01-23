    public class QuoteMailerController : Controller 
    {
        public ActionResult EMailQuote()
        {
            Calculations calc = new Calculations();
            QuoteData quoteData = new QuoteData
            {
                StepFilingInformation = new Models.StepFilingInformation
                {
                    PaymentPlanRadioButton = Models.StepFilingInformation.PaymentPlan.Yes,
                }
             };
             var total = calc.CalculatePrice(quoteData);
        }
    }
