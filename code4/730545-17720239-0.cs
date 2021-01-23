    /// <summary>
	/// Defines an object that has a modifiable (thawed) state and a read-only (frozen) state
	/// </summary>
	/// <remarks>
	/// All derived classes should call <see cref="BeforeValueChanged"/> before modifying any state of the object. This
	/// ensures that a frozen object is not modified unexpectedly.
	/// </remarks>
	/// <example>
	/// This sample show how a derived class should always use the BeforeValueChanged method <see cref="BeforeValueChanged"/> method.
	/// <code>
	/// public class TestClass : Freezable
	/// {
	///    public String Name
	///    {
	///       get { return this.name; }
	///       set
	///       {
	///          BeforeValueChanged();
	///          this.name = name;
	///       }
	///    }
	///    private string name;
	/// }
	/// </code>
	/// </example>
	[Serializable]
	public class Freezable
	{
		#region Locals
		/// <summary>Is the current instance frozen?</summary>
		[NonSerialized]
		private Boolean _isFrozen;
		/// <summary>Can the current instance be thawed?</summary>
		[NonSerialized]
		private Boolean _canThaw = true;
		/// <summary>Can the current instance be frozen?</summary>
		[NonSerialized]
		private Boolean _canFreeze = true;
		#endregion
		#region Properties
		/// <summary>
		/// Gets a value that indicates whether the object is currently modifiable.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is frozen; otherwise, <c>false</c>.
		/// </value>
		public Boolean IsFrozen 
		{
			get { return this._isFrozen; }
			private set { this._isFrozen = value; } 
		}
		/// <summary>
		/// Gets a value indicating whether this instance can be frozen.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance can be frozen; otherwise, <c>false</c>.
		/// </value>
		public Boolean CanFreeze
		{
			get { return this._canFreeze; }
			private set { this._canFreeze = value; }
		}
		/// <summary>
		/// Gets a value indicating whether this instance can be thawed.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance can be thawed; otherwise, <c>false</c>.
		/// </value>
		public Boolean CanThaw
		{
			get { return this._canThaw; }
			private set { this._canThaw = value; }
		}
		#endregion
		#region Methods
		/// <summary>
		/// Freeze the current instance.
		/// </summary>
		/// <exception cref="System.InvalidOperationException">Thrown if the instance can not be frozen for any reason.</exception>
		public void Freeze()
		{
			if (this.CanFreeze == false)
				throw new InvalidOperationException("The instance can not be frozen at this time.");
			this.IsFrozen = true;
		}
		/// <summary>
		/// Does a Deep Freeze for the duration of an operation, preventing it being thawed while the operation is running.
		/// </summary>
		/// <param name="operation">The operation to run</param>
		internal void DeepFreeze(Action operation)
		{
			try
			{
				this.DeepFreeze();
				operation();
			}
			finally
			{
				this.DeepThaw();
			}
		}
		/// <summary>
		/// Applies a Deep Freeze of the current instance, preventing it be thawed, unless done deeply.
		/// </summary>
		internal void DeepFreeze()
		{
			// Prevent Light Thawing
			this.CanThaw = false;
			this.Freeze();
		}
		/// <summary>
		/// Applies a Deep Thaw of the current instance, reverting a Deep Freeze.
		/// </summary>
		internal void DeepThaw()
		{
			// Enable Light Thawing
			this.CanThaw = true;
			this.Thaw();
		}
		/// <summary>
		/// Thaws the current instance.
		/// </summary>
		/// <exception cref="System.InvalidOperationException">Thrown if the instance can not be thawed for any reason.</exception>
		public void Thaw()
		{
			if (this.CanThaw == false)
				throw new InvalidOperationException("The instance can not be thawed at this time.");
			this.IsFrozen = false;
		}
		/// <summary>
		/// Ensures that the instance is not frozen, throwing an exception if modification is currently disallowed.
		/// </summary>
		/// <exception cref="System.InvalidOperationException">Thrown if the instance is currently frozen and can not be modified.</exception>
		protected void BeforeValueChanged()
		{
			if (this.IsFrozen)
				throw new InvalidOperationException("Unable to modify a frozen object");
		}
		#endregion
	}
