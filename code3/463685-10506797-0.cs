    public interface IAnimal {...}
    public class Cat : IAnimal {...}
    public interface IPetSitter
    {
        IAnimal Pet { get; set; }
    }
    public class Kid : IPetSitter
    {
        public Kid (params Type[] allowedPets) {
            _allowedPets = allowedPets;
        }
        readonly IEnumerable<Type> _allowedPets;
        IAnimal _pet;
        public IAnimal Pet 
        {
            get {
                return _pet;
            }
            set {
                if (!_allowedPets.Contains(value.GetType()) {
                    throw new InvalidArgumentException("This instance does not support " + value.GetType().Name + ".");
                }
                _pet = value;
            }
        }
    }
