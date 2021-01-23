        class System
        {
            public string SystemUser { get; set; }
        }
       var query = dataContext.ExecuteQuery<System>("select SYSTEM_USER AS 'SystemUser'");
