    public abstract class People
    {
        public bool GotLegs()
        {
            return true; //Always returns true for both People types
        }
    
        public abstract string GetName();
    }
    public class CityPeople : People
    {
    
        #region IPeople Members
    
        public override string GetName()
        {
            return "City Guy";
        }
    
        #endregion
    }
    public class Villagers : People
    {
    
        #region IPeople Members
    
        public override string GetName()
        {
            return "Village Guy";
        }
    
        #endregion
    }
