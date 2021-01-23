    public class BuildingEqualityComparer : IEqualityComparer<Room>
    {
        public bool Equals(Room x, Room y)
        {
            return x.BuildingName.Equals(y.BuildingName);
        }
        public int GetHashCode(Room obj)
        {
            return obj.BuildingName.GetHashCode();
        }
    }
