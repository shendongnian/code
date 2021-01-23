        public interface IRooms
        {
            List<Room> AvailableRooms();
        }
    
        public interface IRoomBuilder
        {
            //void MakeWall();
            //void MakeWalls(int NumWalls);
            //void MakeCeiling();
            //void MakeCeilings(int NumCeilings);
            void MakeElement(Element el);
            void MakeElements(List<Element> elmts);
        }
    
        public class Room:IRoomBuilder
        {
            private List<Element> roomelements;
            private readonly Rooms ShowRooms;
    
            public List<Element> RoomElements
            {
                get { return roomelements; }
                set { RoomElements.AddRange(value); }
            }
    
            public Room()
            {
                roomelements = new List<Element>();
                ShowRooms = new Rooms();
            }
    
            public void MakeElement(Element el)
            {
                RoomElements.Add(el);
            }
    
            public void MakeElements(List<Element> elmts)
            {
                RoomElements.AddRange(elmts);
            }
    
            //public void MakeWall()
            //{
    
            //    RoomElements.Add(Element.MakeElement(typeof(Wall).Name));
            //}
    
            //public void MakeWalls(int NumWalls)
            //{
            //    for (int i = 0; i < NumWalls; i++)
            //    {
            //        RoomElements.Add(Element.MakeElement(typeof(Wall).Name));
            //    }
            //}
    
            //public void MakeCeiling()
            //{
            //    RoomElements.Add(Element.MakeElement(typeof(Ceiling).Name));
            //}
    
            //public void MakeCeilings(int NumCeilings)
            //{
            //    for (int i = 0; i < NumCeilings; i++)
            //    {
            //        RoomElements.Add(Element.MakeElement(typeof(Ceiling).Name));
            //    };
            //}
    
            public void AddRoom()
            {
                ShowRooms.Add(this);
            }
    
            public List<Room> GetAllRooms()
            {
                IRooms r = (IRooms)ShowRooms;
                return r.AvailableRooms();
            }
    
            public override string ToString()
            {
                return "I am a room with " + RoomElements.Count.ToString() + " Elements";
            }
    
            private class Rooms : List<Room>,IRooms
            {  
                List<Room> IRooms.AvailableRooms()
                {
                    return this;
                }
            }
        }
    
        public abstract class Element
        {
            //this method is used for the commented methods
            public static Element MakeElement(string name)
            {
                if (name == typeof(Ceiling).Name)
                    return new Ceiling() as Element;
                else if (name == typeof(Wall).Name)
                    return new Wall() as Element;
                else
                    throw new ArgumentException("Parameter not valid");
            }
        }
    
        public class Ceiling : Element
        {
            //your implementation.
    
            public override string ToString()
            {
                return "I am a ceiling";
            }
        }
    
        public class Wall : Element
        {
            //your implementation.
    
            public override string ToString()
            {
                return "I am a wall!";
            }
        }
