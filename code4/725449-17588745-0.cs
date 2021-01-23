    UITestControlCollection controls = this.UIMap.clickContinueButton.FindMatchingControls();
    if ( controls.Count == 0 ) {
        // The button is not present.
    } else if ( controls.Count == 1) {
        // The button is present.
    } else {
        // More than one button has been found.
    }
