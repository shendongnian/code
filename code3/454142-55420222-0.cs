    services.AddTransient<IWarehouseRepo, ActionRepository>();
    services.AddTransient<IWarehouseRepo, EventRepository>();
    services.AddTransient<IWarehouseRepo, AuditRepository>();
    services.AddTransient<IWarehouseRepo, ProRepository>();
    services.AddTransient<IWarehouseRepo, SuperWarehouseRepository>();
    services.AddTransient<IWarehouseRepo, InferiorWarehouseRepository>();
    services.AddTransient<IWarehouseRepo, MonthlyStatisticsRepository>();
