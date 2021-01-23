	namespace WpfApplication1
	{
		public class Castle
		{
			public Castle(bool mark, string description)
			{
				CastleMarked = mark;
				CastleDescription = description;
			}
			bool CastleMarked { get; set; }
			string CastleDescription { get; set; }
		}
		public partial class MainWindow : Window
		{
			public MainWindow()
			{
				InitializeComponent();
				Castle cas1 = new Castle(true, "Stone");
			}
		}
	}
