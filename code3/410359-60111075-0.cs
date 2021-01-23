    public abstract class Logic
    {
        private Logic() { }
        public abstract void acceptPlayer(Player player);
        public sealed class PayDay : Logic
        {
            public PayDay(DateTime timeOfPayment)
            {
                TimeOfPayment = timeOfPayment;
            }
    
            public DateTime TimeOfPayment { get; }
        
            public override void acceptPlayer(Player player)
            {
                // Perform logic
            }
        }
        public sealed class CollectCash : Logic
        {
            public CollectCash(int amountOfMoney)
            {
                AmountOfMoney = amountOfMoney;
            }
    
            public int AmountOfMoney { get; }
    
            public override void acceptPlayer(Player player)
            {
                // Perform logic
            }
        }
    
        public sealed class EtcEtc : Logic
        {
            public override void acceptPlayer(Player player)
            {
                // Perform logic
            }
        };
    }
