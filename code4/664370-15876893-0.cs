	/// <summary>Specifies the behavior for a forced garbage collection.</summary>
	/// <filterpriority>2</filterpriority>
	[__DynamicallyInvokable]
	[Serializable]
	public enum GCCollectionMode
	{
		/// <summary>The default setting for this enumeration, which is currently <see cref="F:System.GCCollectionMode.Forced" />. </summary>
		Default,
		/// <summary>Forces the garbage collection to occur immediately.</summary>
		Forced,
		/// <summary>Allows the garbage collector to determine whether the current time is optimal to reclaim objects. </summary>
		Optimized
	}
