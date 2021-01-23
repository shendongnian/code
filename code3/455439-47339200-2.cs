        public interface ICar
    {
        string CarModel { get; }
        string Drive { get; }
        string Reverse { get; }
    }
    public class Lamborghini : ICar
    {
        private string _carmodel;
        public string CarModel { get => _carmodel; }
        public string Drive => "Drive the Lamborghini forward!";
        public string Reverse => "Drive the Lamborghini backward!";
        public Lamborghini()
        {
            _carmodel = "Lamborghini";
        }
    }
