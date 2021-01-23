    // System.Diagnostics.PerformanceCounter
    /// <summary>Frees the performance counter library shared state allocated by the counters.</summary>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1">
    ///     <Machine name=".">
    ///       <Category name="*" access="Browse" />
    ///     </Machine>
    ///   </IPermission>
    /// </PermissionSet>
    public static void CloseSharedResources()
    {
    	PerformanceCounterPermission performanceCounterPermission = new PerformanceCounterPermission(PerformanceCounterPermissionAccess.Browse, ".", "*");
    	performanceCounterPermission.Demand();
    	PerformanceCounterLib.CloseAllLibraries();
    }
