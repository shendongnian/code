    public class ParentGameObjects : MonoBehaviour {
        //The tag to search for on all game objects in the hierarchy
        public String objectTag;
        
        //The game objects that we will parent the main camera to
        private GameObject[] children;
        //It's not necessary to store references to the children but if you want to modify them at some point you will be able to
        
        void Start() {
            //Find all game objects with the tag we want
            children = GameObject.FindGameObjectsWithTag(objectTag);
            //Loop through all of the game objects found and parent this object's transform
            for(int i = 0; i < children.Length; i++) {
                children[i].transform.parent = transform;
            }
        }
    }
