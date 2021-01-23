    class MadeUp
    {
        public int A;
        public DateTime B;
        public string C;
        public Guid D;
    }
    var verySorted = madeUps.OrderBy(m => m.A)
                        .ThenBy(m => m.B)
                        .ThenByDescending(m => m.C)
                        .ThenBy(m => m.D);
