    public class MyDto
    {
        public Rating Rating { get; set; }
        [ContractInvariantMethod]
        void Invariant()
        {
            Contract.Invariant(Enum.IsDefined(typeof(Rating), Rating));
        }
    }
