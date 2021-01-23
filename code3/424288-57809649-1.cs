        public string CC_NUM { get; set; }
    
        /// <summary>
        /// getCardType()
        /// </summary>
        /// <returns>Matches a object reference to regex to bring back a card type, the validity of the card, or a default (Unknown)</returns>
        public CreditCardType getCardType()
        {
            return new Regex(@"^4[0-9]{6,}$").IsMatch(CC_NUM) ? CreditCardType.Visa :
                   new Regex(@"^5[1-5][0-9]{5,}|222[1-9][0-9]{3,}|22[3-9][0-9]{4,}|2[3-6][0-9]{5,}|27[01][0-9]{4,}|2720[0-9]{3,}$").IsMatch(CC_NUM) ? CreditCardType.MasterCard :
                   new Regex(@"^3[47][0-9]{5,}$").IsMatch(CC_NUM) ? CreditCardType.AmericanExpress :
                   new Regex(@"^65[4-9][0-9]{13}|64[4-9][0-9]{13}|6011[0-9]{12}|(622(?:12[6-9]|1[3-9][0-9]|[2-8][0-9][0-9]|9[01][0-9]|92[0-5])[0-9]{10})$").IsMatch(CC_NUM) ? CreditCardType.Discover :
                   new Regex(@"^3[47][0-9]{13}$").IsMatch(CC_NUM) ? CreditCardType.Amex :
                   new Regex(@"^(6541|6556)[0-9]{12}$").IsMatch(CC_NUM) ? CreditCardType.BCGlobal :
                   new Regex(@"^389[0-9]{11}$").IsMatch(CC_NUM) ? CreditCardType.CarteBlanch :
                   new Regex(@"^3(?:0[0-5]|[68][0-9])[0-9]{11}$").IsMatch(CC_NUM) ? CreditCardType.DinersClub :
                   new Regex(@"^63[7-9][0-9]{13}$").IsMatch(CC_NUM) ? CreditCardType.InstaPaymentCard :
                   new Regex(@"^(?:2131|1800|35\d{3})\d{11}$").IsMatch(CC_NUM) ? CreditCardType.JCBCard :
                   new Regex(@"^9[0-9]{15}$").IsMatch(CC_NUM) ? CreditCardType.KoreanLocal :
                   new Regex(@"^(6304|6706|6709|6771)[0-9]{12,15}$").IsMatch(CC_NUM) ? CreditCardType.LaserCard :
                   new Regex(@"^(5018|5020|5038|6304|6759|6761|6763)[0-9]{8,15}$").IsMatch(CC_NUM) ? CreditCardType.Maestro :
                   new Regex(@"^(6334|6767)[0-9]{12}|(6334|6767)[0-9]{14}|(6334|6767)[0-9]{15}$").IsMatch(CC_NUM) ? CreditCardType.Solo :
                   new Regex(@"^(4903|4905|4911|4936|6333|6759)[0-9]{12}|(4903|4905|4911|4936|6333|6759)[0-9]{14}|(4903|4905|4911|4936|6333|6759)[0-9]{15}|564182[0-9]{10}|564182[0-9]{12}|564182[0-9]{13}|633110[0-9]{10}|633110[0-9]{12}|633110[0-9]{13}$").IsMatch(CC_NUM) ? CreditCardType.SwitchCard :
                   new Regex(@"^(62[0-9]{14,17})$").IsMatch(CC_NUM) ? CreditCardType.UnionPay :
                   CC_NUM.Where((e) => e >= '0' && e <= '9').Reverse().Select((e, i) => ((int)e - 48) * (i % 2 == 0 ? 1 : 2)).Sum((e) => e / 10 + e % 10) == 0 ? CreditCardType.NotFormatted :
                   CreditCardType.Unknown;
        }
        /// <summary>
        /// isCreditCardAccepted()
        /// </summary>
        /// <returns>Checks to see if the credit card is allowed by comparing it to the integer value of CreditCardType to a local array of allowed integers</returns>
        public bool isCreditCardAccepted()
        {
            // This should honestly be internalized somewhere for security reasons
            int[] allowed = new int[] { 0, 1, 2, 3 };
            return Array.IndexOf(allowed, getCardType()) >= 0;
        }
        public enum CreditCardType
        {
            Visa             = 0,
            MasterCard       = 1,
            AmericanExpress  = 2,
            Discover         = 3,
            Amex             = 4,
            BCGlobal         = 5,
            CarteBlanch      = 6,
            DinersClub       = 7,
            InstaPaymentCard = 8,
            JCBCard          = 9,
            KoreanLocal      = 10,
            LaserCard        = 11,
            Maestro          = 12,
            Solo             = 13,
            SwitchCard       = 14,
            UnionPay         = 15,
            NotFormatted     = 16,
            Unknown          = 17
        }
