    public abstract class AnimalBase
    {
        public string SpeciesName { get; private set; }
        protected AnimalBase(string speciesName)
        {
            this.SpeciesName = speciesName;
        }
    }
    public class Mammal : AnimalBase
    {
        public bool WalksUpright { get; set; }
        public Mammal(string speciesName) : base(speciesName)
        {
        }
        public void Cripple()
        {
            this.WalksUpright = false;
        }
    }
    public interface IAnimalFactory<T> where T : AnimalBase
    {
        T CreateAnAnimal(string speciesName);
    }
    public class MammalFactory: IAnimalFactory<Mammal>
    {
        public Mammal CreateAnAnimal(string speciesName)
        {
            var mammal = new Mammal(speciesName);
            var mammalDefault = new MammalDefaultClass(speciesName);
            mammal.WalksUpright = mammalDefault.WalksUpright;
            return mammal;
        }
    }
