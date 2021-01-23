    class BetList : List<Bet>
    {
        public uint Sum { get; private set; }
        new void Add(Bet bet) 
        {
            base.Add(bet);
            Sum += bet.Amount;
        } 
    }
