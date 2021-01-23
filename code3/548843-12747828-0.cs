    public struct DynamicState
    {
    	[MarshalAs (UnmanagedType.ByValArray, SizeConst=3)]
    	public double[] Position;
    
    	[MarshalAs (UnmanagedType.ByValArray, SizeConst=3)]
    	public double[] Velocity;
    
    	[MarshalAs (UnmanagedType.ByValArray, SizeConst=3)]
    	public double[] Acceleration;
    
    	[MarshalAs (UnmanagedType.ByValArray, SizeConst=3)]
    	public double[] Attitude;
    
    	[MarshalAs (UnmanagedType.ByValArray, SizeConst=3)]
    	public double[] AngularVelocity;
    }
