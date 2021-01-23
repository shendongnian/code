    public class Notification
    {
       public int UserId { get; set; }
       public int[,] Profiles { get; set; }
    }
    Content-Type: application/json
    {
        UserId: 1,
        Profiles: [[1,2]]
    } 
