    public GameController(DirectInput directInput, Game game, int number)
    {
        // Search for Device
        var devices = directInput.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly);
        if (devices.Count == 0 || devices[number] == null)
        {
            // No Device
            return;
        }
        // Create Gamepad
        joystick = new Joystick(directInput, devices[number].InstanceGuid);  
        joystick.SetCooperativeLevel(game.Window.Handle, CooperativeLevel.Exclusive | CooperativeLevel.Foreground);
        // Set Axis Range for the Analog Sticks between -1000 and 1000 
        foreach (DeviceObjectInstance deviceObject in joystick.GetObjects())
        {
            if ((deviceObject.ObjectType & ObjectDeviceType.Axis) != 0)
                joystick.GetObjectPropertiesById((int)deviceObject.ObjectType).SetRange(-1000, 1000);
        }
        joystick.Acquire();
    }
