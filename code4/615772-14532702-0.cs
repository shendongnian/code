    private static GameConfig _instance = null;
    public static GameConfig instance 
    {
        get {
            if (!_instance) {
                //check if an GameConfig is already in the scene
                _instance = FindObjectOfType(typeof(GameConfig)) as GameConfig;
            
                //nope create one
            if (!_instance) {
                var obj = new GameObject("GameConfig");
                DontDestroyOnLoad(obj);
                _instance = obj.AddComponent<GameConfig>();
                }
            }
            return _instance;
        }
    }
