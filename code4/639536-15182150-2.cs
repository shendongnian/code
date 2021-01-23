    private Root mRoot;
    private SceneManager mgr;
    private Camera cam;
    public Form1()
    { 
        mRoot = new Root();
        mgr = mRoot.CreateSceneManager(SceneType.ST_GENERIC);
        cam = mgr.CreateCamera("Camera");
    }
