    class Accum
    {
        private int sum, count;
    
        public event AverageChanged; 
        public void Add(int value)
        {
           sum += value;
           count += 1;
           if (count >= 100)
           {
               OnAvarerageChanged(sum/count);
               sum = 0;
               count = 0;
           }
        }
        ....
    }
