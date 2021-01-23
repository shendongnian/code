    public class AudioManager : MonoBehaviour {
		private static AudioManager instance = null;
		public static AudioManager SharedInstance {
			get {
				if (instance == null) {
					instance = MainComponentManger.AddMainComponent<AudioManager> ();
				}
				return instance;
			}
		}
		
