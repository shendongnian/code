    class FormSettings : ApplicationSettingsBase
	{
		public WindowSettings() {}
		public WindowSettings(string settingsKey) : base(settingsKey) {}
		[UserScopedSettingAttribute()]
		[DefaultSettingValueAttribute("MyDefaultName")]
		public String Name
		{
			get { return (string)(this["Name"]); }
			set { this["Name"] = value; }
		}
    }
