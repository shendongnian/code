    public class MusicManagerScript : MonoBehaviour
    {
        private static MusicManagerScript instance = null;
        public AudioClip[] songs;
        int currentSong = 0;
        void Awake()
        {
            if (instance != null)
            {
                Destroy(this);
                return;
            }
            instance = this;
        }
        // Use this for initialization
        void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
        // Update is called once per frame
        void Update()
        {
            if (audio.isPlaying == false)
            {
                currentSong = currentSong % songs.Length;
                audio.clip = songs[currentSong];
                audio.Play();
                currentSong++;
            }
        }
        void OnDestroy()
        {
            //If you destroy the singleton elsewhere, reset the instance to null, 
            //but don't reset it every time you destroy any instance of MusicManagerScript 
            //because then the singleton pattern won't work (because the Singleton code in 
            //Awake destroys it too)
            if (instance == this)
            {
                instance = null;
            }
        }
    }
