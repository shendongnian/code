	class MyContext : ContentProcessorContext
	{
		public override string BuildConfiguration { get { return ""; } }
		public override TargetPlatform TargetPlatform { get { return TargetPlatform.Windows; } }
		public override GraphicsProfile TargetProfile { get { return GraphicsProfile.HiDef; } }
		// ... other overrides ...
	}
