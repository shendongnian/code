    private List<GameObject> queue; // assuming it's private, doesn't really matter either way.
    static void Main()
    {
        queue = new List<GameObject>(); // the missing line
        GameObject obj1 = new GameObject();
        GameManager manager1 = new GameManager();
        obj1.name = "First";
        manager1.Add(obj1);
        manager1.Process();
    }
    public void Add(GameObject gameObject)
    {
        gameObject.initialize = true;
        queue.Add(gameObject);
    }
