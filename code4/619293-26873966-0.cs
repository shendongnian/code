		static void Main()
		{
			IUnityContainer container = new UnityContainer();
			container
				.RegisterType<MainForm>()
				.RegisterInstance<IUnityContainer>(container);
.
		public partial class MainForm: Form
		{
			[Dependency]
			public IUnityContainer Container { get; set; }
