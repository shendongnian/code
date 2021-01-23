    public sealed class Logic
    {
        public static readonly Logic PayDay = new Logic(PayDayAccept);
        public static readonly Logic CollectCash = new Logic(CollectCashAccept);
        public static readonly Logic EtcEtc = new Logic(player => {
            // An alternative using lambdas...
        });
        
        private readonly Action<Player> accept;
        
        private Logic(Action<Player> accept)
        {
            this.accept = accept;
        }
        
        public void AcceptPlayer(Player player)
        {
            accept(player);
        }
    
        private static void PayDayAccept(Player player)
        {
            // Logic here
        }
    
        private static void CollectCashAccept(Player player)
        {
            // Logic here
        }
    }
