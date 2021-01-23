    private Region _myRegion = null;
    private void SomeMethod() {
        _myRegion = CreateRegion(YourMaskBitmap);            
    }
    private void SomeOtherMethod() {
        this.Region = _myRegion.Clone();
    }
