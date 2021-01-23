    	[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("")]
		public YourType PropertyName
		{
			get => (YourType)this["PropertyName"];
			set => this["PropertyName"] = value;
		}
