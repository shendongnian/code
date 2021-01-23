        public class RetourenNeu
        {
            public string Artikel { get; set; }
            public int? Retourengrund { get; set; }
            public decimal? Anzahl { get; set; }
        }
        public class RetourenPivot
        {
            public string Artikel { get; set; }
            public IEnumerable<int?> Retourengrund { get; set; }
            public IEnumerable<decimal?> Anzahl { get; set; }
        }
