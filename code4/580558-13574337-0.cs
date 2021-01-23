    public interface IUnitDataProvider
    {
        void AddChildrenUnit(Unit unit, string connectionString);
    }
    public class UnitService:IUnitDataProvider
    {
        //Implement AddChildrenUnit the way want
        //pass the connection string but u dont use it
    }
    public interface UnitDataProvider:IUnitDataProvider
    {
        //Implement AddChildrenUnit the way want
    }
 
