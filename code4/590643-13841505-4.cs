    public abstract class RoomObject<T> where T : new()
    {
        protected T CreateRoomObjectCopy(T roomObject)
        {
            T concreteType = new T();
            //Copy Room object properties
            return concreteType;
        }
        public abstract T Copy(T roomObject);
    }
    public class Bed : RoomObject<Bed>
    {
        public override Bed Copy(Bed roomObject)
        {
            Bed newBed = CreateRoomObjectCopy(roomObject);
            //Copy bed properties
            return newBed;
        }
    }
