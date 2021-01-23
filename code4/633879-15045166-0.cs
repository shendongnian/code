    public class SoundLoader : MonoBehaviour {
	public AudioClip[] menuSound;
	void Start () {
		menuSound = new AudioClip[]{
			Resources.Load("sound1") as AudioClip,
			Resources.Load("sound2") as AudioClip,
			Resources.Load("sound3") as AudioClip
    	};
		AudioSource.PlayClipAtPoint(menuSound[2],Vector3.zero);
	}
    }
