    public class Model1 
    {
        public int model1ID { get; set; }
        public int model2ID { get; set; }
        public virtual Model2 model2 { get; set; }
    }
    public class Model2
    {
        public int model2ID { get; set; }
    }
