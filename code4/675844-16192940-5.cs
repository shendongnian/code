    public JoystickState GetState()
    {
        if (joystick.Acquire().IsFailure || joystick.Poll().IsFailure)
        {
            state = new JoystickState();
            return state;
        }
        state = joystick.GetCurrentState();
        return state;
    }
