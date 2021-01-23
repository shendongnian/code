    interface IChangeTracker
    {
        bool Materialized { get; set; }
        bool OutsideDbNeedsUpdate { get; }
    }
