    // this is your UI form/control/whatever
    public class MyUI
    {
        public void OnButtonToGetRateClick()
        {
            var from = "USD"; // or read from textbox...
            var to = "EUR";
            // call the rate service
            var service = new GoogleCurrencyService();
            service.GetRateForCurrency(from, to, (rate) =>
                {
                    // do stuff here to update UI.
                    // like update ui.
                });
        }
    }
