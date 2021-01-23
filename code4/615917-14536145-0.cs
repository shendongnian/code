        private static Server ServerObject {
            get { 
                if (_serverObject == null) {
                    var gameObj = new GameObject("Server Object");
                    _serverObject = gameObj.AddComponent<Server>();
                    GameObject.DontDestroyOnLoad(_serverObject); // Optional
                }
                return _serverObject;
            }
        }
        private static Server _serverObject;
