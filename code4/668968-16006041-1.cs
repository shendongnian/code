    public class BaseStatComponent : MonoBehaviour {
        [System.Serializable]
        public class baseStats {
           public int Example;
        }
        public baseStats mainChar; //this will be accessible to inspector now.
        void Start() {
            // This will always create a new instance of baseStats that overrides the values
            // set in inspector.  Remove this line if you want the values set in the
            // inspector to remain.
            mainChar = new baseStats { Example = 12 };
        }
    }
