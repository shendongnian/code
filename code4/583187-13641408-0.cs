    public enum AccessRights
    {
        LogisticsCoordinator_RW, //Read-Write,
        LogisticsCoordinator_R, //Read only Purchasing and Inventory
        ProcurementManager_RW, // Read-Write access to track purchase of Sand on monitor on hand Inventory
        ProcurementManager_R, //read access to Create Frac Jobs , Dispatch and reroute
        SystemAdministrator, //Full Rights to Vertex_Personnel only
        StudentManagement_R, //Read Access Only 
        AppAdministrator_R,
        NonAdmin,
        None,
        Full,
        Default
    }
