    public IQueryable<ChatLogsNameViewModel> getChatLogWithName()
        {
                var list = (from b in this.ChatLogs
                            select new ChatLogsNameViewModel()
                            {
                                UserProfile = b.UserProfile,
                                Message = b.Message,
                                Time = b.Time
                            });
    
                return list;
        }
