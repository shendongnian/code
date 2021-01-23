    public class Sample
    {
        private decimal sum = 0;
        private uint count = 0;
    
        public void Add(decimal value)
        {
            sum += value;
            count++;
        }
    
        public decimal AverageMove => count > 0 ? sum / count : 0;
    }
