    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T value);
    }
    
    public class ZajezdSpecification : ISpecification<Zajezd>
    {
        private string _zeme;
        private string _oblast;
        private string _stredisko;
        private string _doprava;
        private string _strava;
        private int _cenaOd;
        private int _cenaDo;
    
        public ZajezdSpecification(string zeme, string oblast, string stredisko, 
            string doprava, string strava, int cenaOd, int cenaDo)
        {
            _zeme = zeme;
            _oblast = oblast;
            _stredisko = stredisko;
            _doprava = doprava;
            _strava = strava;
            _cenaOd = cenaOd;
            _cenaDo = cenaDo;
        }
    
        public bool IsSatisfiedBy(Zajezd zajezd)
        {
            if (!String.IsNullOrEmpty(_zeme) && zajezd.Zeme != _zeme)
                return false;
    
            if (!String.IsNullOrEmpty(_oblast) && zajezd.Oblast != _oblast)
                return false;
    
            // ... verify anything you want
    
            return _cenaOd < zajezd.CenaOd && zajezd.CenaOd < _cenaDo;
        }
    }
