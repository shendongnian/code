    private static WarehouseSystemDataContext _dc
    private static WarehouseSystemDataContext dc
    {
        get
        {
            if(_dc == null)
            {
            // It is being passed a closed SqlConnection object
            _dc = new WarehouseSystemDataContext(Constants.getWarehouseSystemConn());
            _dc.ObjectTrackingEnabled = false;
            _dc.CommandTimeout = 600;
            }
            return _dc;
            
        }
    }
