    public abstract class DiseaseBase
    {
        public abstract void Spread();
    }
    
    public class Anthrax : DiseaseBase
    {
        public override void Spread()
        {
            GetPostedToPolitician();
        }
    }
    public class BirdFlu : DiseaseBase
    {
        public override void Spread()
        {
            Cluck();
            SneezeOnHuman();
        }
    }
    public class SwineFlu : DiseaseBase
    {
        public override void Spread()
        {
            //roll in mud around other piggies
        }
    }
    public class ManFlu : DiseaseBase
    {
        public override void Spread()
        {
            //this is not contagious
            //lie in bed and complain
            //get girlfriend to make chicken soup
            //serve chicken soup with beer and baseball/football/[A-Za-z0-9]+Ball
        }
    }
    
    public List<DiseaseBase> DiseaseCollection = new List<Disease>();
