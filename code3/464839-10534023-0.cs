    //In Camera.cs
    Scrolling.Update(oldCameraPosition - cameraPosition);
    
    //In your scrolling class
    void Update(Vector3 offset)
    {
     background.Position += offset * .5f;
    }
