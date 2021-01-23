    public class CardTypeConverter
    {
        public static Y.CardType Convert(X.CardType cardType)
        {
            switch(cardType)
            {
                ...
                case X.CardType.VisaCredit:
                case X.CardType.VisaDebit:
                    return Y.CardType.Visa;
                ...
            }
        }
    }
