    public class Cell
    {
        private GameObject instance;
        public void CreateVisual()
        {
            // Load a GameObject that exist inside the "Resources" folder.
            GameObject prefab = (GameObject)Resources.Load("Models/Walls/3W1"); 
    
            // Create an instance of the prefab
            instance = (GameObject)GameObject.Instantiate(prefab);
            instance.transform.position = myPosition;
        }
    }
