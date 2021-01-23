    public List<ChatLogsNameViewModel> getChatLogWithName()
        {
            using (var db = new ChatLogContext())
            {
                var list = (from b in db.ChatLogs
                            select new ChatLogsNameViewModel()
                            {
                                UserProfile = b.UserProfile,
                                Message = b.Message,
                                Time = b.Time
                            });
    
                return list.ToList();
            }
        }
