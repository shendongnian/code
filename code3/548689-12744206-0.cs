    interface IOrganism
    {
        string GetSpecies();
    }
    abstract class Animal : IOrganism
    {
        abstract string GetSpecies();
    }
    class Rat : Animal
    {
       public virtual string GetSpecies()
       {
          return "Ratus";
       }
    }
    sealed class BlackRat : Rat
    {
        public override string GetSpecies()
        {
           return string.Format("{0} Ratus", base.GetSpecies()));
        }
    }
