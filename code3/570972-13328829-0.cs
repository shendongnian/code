            GlobalHost.Configuration.ConnectionTimeout = TimeSpan.FromSeconds(50);
            RouteTable.Routes.MapHubs();
    public class ComputeUnits : Hub
    {
         public Task Running(Guid MyGuid)
         {
             return Clients.Group(MyGuid.ToString()).ComputeUnitHeartBeat(MyGuid,
                    DateTime.UtcNow.ToEpochMilliseconds());            
         }
         public Task ComputeUnitReqister(Guid MyGuid)
         {
             Groups.Add(Context.ConnectionId, "ComputeUnits").Wait(); 
             return Clients.Others.ComputeUnitCameOnline(new { Guid = MyGuid,
                    HeartBeat = DateTime.UtcNow.ToEpochMilliseconds() });           
         }
         public void SubscribeToHeartBeats(Guid MyGuid)
         {
             Groups.Add(Context.ConnectionId, MyGuid.ToString());
         }
    }
