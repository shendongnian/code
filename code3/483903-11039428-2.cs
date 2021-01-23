    private void SwitchControls(ControlType pType) {
        // Keep a reference to whichever control is currently in MainPanel.
        Control ctlOld = MainPanel.Controls[0];
        // Create a new Control object
        Control ctlNew = null;
        // Make a switch statement to find the correct type of Control to create.
        switch (pType) {
            case (ControlType.Gear):
               ctlNew = new ctlGear();
               break;
            case (ControlType.Map):
               ctlNew = new ctlMap();
               break;
            case (ControlType.Graph):
               ctlNew = new ctlGraph();
               break;
            case (ControlType.Car):
                ctlNew = new ctlCar();
                break;
            case (ControlType.Person):
                ctlNew = new ctlPerson();
                break;
            // don't worry about a default, unless you have one you would want to be the default.
        }
        // Don't try to add a null Control.
        if (ctlNew == null) return();
        MainPanel.Controls.Add(ctlNew);
        MainPanel.Controls.Remove(ctlOld);
    }
