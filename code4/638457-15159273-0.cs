    public class CarBootSaleList : IEnumerable<CarBootSale>
    {
        private List<CarBootSale> carbootsales;
        
        ...
        
        public IEnumerator<CarBootSale> GetEnumerator()
        {
            return carbootsales.GetEnumerator();
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return carbootsales.GetEnumerator();
        }
    }
