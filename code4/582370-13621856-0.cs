    void Rent(IMovie movie)
    {
        var price = movie.Price();
        movie.MarkReserved();
    }
    
    public interface IMovie { }
    
    public class Oldie : IMovie
    {
        private decimal _oldieRate = 0.8;
    
        public decimal Price()
        {
            return MainData.RentPrice * _oldieRate;
        }
        public decimal MarkReserved()
        {
            _oldiesDb.MarkReserved(this, true);
        }
    }
    
    
    public class Blockbuster : IMovie
    {
        private decimal _blockbusterRate = 1.2;
    
        public decimal Price()
        {
            return MainData.RentPrice * _blockbusterRate ;
        }
        public decimal MarkReserved()
        {
            _regularDb.MarkReserved(this, true);
        }
    }
