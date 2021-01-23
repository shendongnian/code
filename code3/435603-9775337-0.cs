    /// <summary>
	/// Base class for drop shadows forms.
	/// </summary>
	public partial class DropShadowForm : Form
	{
		private const int CS_DROPSHADOW = 0x00020000;
		/// <summary>
		/// Creates new instance of DropShadowForm.
		/// </summary>
		public DropShadowForm()
		{
			InitializeComponent();
		}
		/// <summary>
		/// Overrides from base class.
		/// </summary>
		protected override CreateParams CreateParams
		{
			[SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
			get
			{
				CreateParams parameters = base.CreateParams;
				if (DropShadowSupported)
				{
					parameters.ClassStyle = (parameters.ClassStyle | CS_DROPSHADOW);
				}
				return parameters;
			}
		}
		/// <summary>
		/// Gets indicator if drop shadow is supported
		/// </summary>
		public static bool DropShadowSupported
		{
			get
			{
				OperatingSystem system = Environment.OSVersion;
				bool runningNT = system.Platform == PlatformID.Win32NT;
				return runningNT && system.Version.CompareTo(new Version(5, 1, 0, 0)) >= 0;
			}
		}		
	}
