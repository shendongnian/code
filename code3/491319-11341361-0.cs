    public class Room 
    {
    public List<Wall> Walls{get;set;}
    
    }
    
    public class Wall
    {
    decimal length;
    decimal width;
    public List<Room> Rooms{get;set;}
    }
    
    public class RoomWallMapping
    {
    public int MappingID;
    public Wall {get;set;}
    public Room{get;set;}
    }
