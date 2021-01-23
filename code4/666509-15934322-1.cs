    public class GradeHolder
    {
        private int[] counts = new int[100];
    
        public int[] Counts 
        { 
           get { return this.counts; }
           set { this.counts = value; }
    
        public int this[int grade]
        {
            get { return this.counts[grade];}
            set { this.counts[grade] = value; }
        }
    }
