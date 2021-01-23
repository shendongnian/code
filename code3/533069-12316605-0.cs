	public class Globals
	{
		private static Globals instance = new Globals();
		protected Globals()
		{
			Tracklist = new TrackList();
		}
		public static Globals Instance
		{
			get { return instance; }
		}
		public TrackList Tracklist { get; private set; }
	}
