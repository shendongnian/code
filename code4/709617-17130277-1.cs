    public float boundary = 50;
    public float speed = 4;
    private Rect bottomBorder;
    private Rect topBorder;
    private Transform cameraTransform;
    
    private void Start()
    {
        cameraTransform = Camera.mainCamera.transform
        bottomBorder = new Rect(0, 0, Screen.width, boundary);
        topBorder = new Rect(0, Screen.height - boundary, Screen.width, boundary);
    }
    private void Update()
    {
        if (topBorder.Contains(Input.mousePosition))
        {
            position.y += speed * Time.deltaTime;
        }
        if (bottomBorder.Contains(Input.mousePosition))
        {
            position.y -= speed * Time.deltaTime;
        }
        cameraTransform.position = position;
    }
