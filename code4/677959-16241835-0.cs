    public class UnitBase : IUnit
    {
        public DateTime CreateDateTime { get; protected set; }
        DateTime IUnit.CreatedDateTime
        {
            get; set;
        }
    }
