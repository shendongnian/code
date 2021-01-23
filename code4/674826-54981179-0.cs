    [HubName("PublicHub")]
    public class PublicHub : HubBase
    {
        /// <summary>
        /// join group
        /// </summary>
        /// <param name="userLoginName"></param>
        /// <param name="hotelId"></param>
        /// <param name="groupCode"></param>
        [HubMethodName("JoinGroup")]
        public async Task JoinGroupAsync(string userLoginName, string hotelId, string groupCode)
        {
            await Groups.Add(Context.ConnectionId, ShopGroupKey(hotelId, groupCode));
            Clients.Group(ShopGroupKey(hotelId, groupCode)).UpdateRoomStatus("UpdateRoomStatus", "UpdateRoomStatus");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userLoginName"></param>
        /// <param name="hotelId"></param>
        /// <param name="groupCode"></param>
        [HubMethodName("QuitGroup")]
        public async Task QuitGroupAsync(string userLoginName, string hotelId, string groupCode)
        {
            await Groups.Remove(Context.ConnectionId, ShopGroupKey(hotelId, groupCode));
        }
    }
