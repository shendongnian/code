    void Start()
    {
        ...  
    }
    
    public void DoShake()
    {
        OriginalPos = transform.position;
        OriginalRot = transform.rotation;
    
        ShakeIntensity = 0.3f;
        ShakeDecay = 0.02f;
        Shaking = true;
    }... 
