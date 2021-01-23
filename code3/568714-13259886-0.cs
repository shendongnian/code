    bool SpacebarPressed = false;
    private void KeyDown() {
        if (!SpacebarPressed) {
            SpacebarPressed = true;
            DoSomethingWithSpacebarBeingPressed();
        }
    }
    private void KeyUp() {
        if (SpacebarPressed) SpacebarPressed = false;
    }
