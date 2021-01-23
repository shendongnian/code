    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            StripeConfiguration.SetApiKey("[API Secret Key");
            NameValueCollection nvc = Request.Form;
            string amount = nvc["amount"];
            var centsArray = amount.Split('.');
            int dollarsInCents = Convert.ToInt32(centsArray[0]) * 100;
            int remainingCents = Convert.ToInt32(centsArray[1]);
            string tokenId = nvc["stripeToken"];
            var tokenService = new StripeTokenService();
            StripeToken stripeToken = tokenService.Get(tokenId);
            var myCharge = new StripeChargeCreateOptions
            {
                TokenId = tokenId, 
                AmountInCents = dollarsInCents + remainingCents,
                Currency = "usd"
            };
            var chargeService = new StripeChargeService();
            StripeCharge stripeCharge = chargeService.Create(myCharge);
        }
    }
