    public interface IProductionLineGroupFormatter<out T> where T : ProductionLine
    {
        public string Name { get; set; }
        public IEnumerable<T> ProductionLines { get; set; }
    }
