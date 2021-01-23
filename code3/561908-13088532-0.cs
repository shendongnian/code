    private System.Object lockThis = new System.Object(); 
    public override MyObject Load()
    {
        lock (lockThis) {
            if (!IsModelLoaded)
            {
                Model = MyService.LoadMyObject(Model);
                IsModelLoaded = true;
            }
        }
        return Model;
    }
