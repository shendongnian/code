    // System.Environment
    /// <summary>Gets the number of milliseconds elapsed since the system started.</summary>
    /// <returns>A 32-bit signed integer containing the amount of time in milliseconds that has passed since the last time the computer was started.</returns>
    /// <filterpriority>1</filterpriority>
    public static extern int TickCount
    {
    	[SecuritySafeCritical]
    	[MethodImpl(MethodImplOptions.InternalCall)]
    	get;
    }
