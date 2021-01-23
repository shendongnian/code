    static class CardExtensions
    {
       public static int GetValue(this CardValue card)
       {
           switch(card)
           {
               case Jack:
               case Queen:
               case King:
                 return 10;
               default:
                 return (int)card;
           }
       }
    }
