    public override void HandleInput()
    {
        if (ControllingPlayer.HasValue && GamePad.GetState(ControllingPlayer.Value).IsButtonDown(controls.BUp))
        {
            P1movementY--;
        }
        if (ControllingPlayer2.HasValue && GamePad.GetState(ControllingPlayer2.Value).IsButtonDown(controls.BUp))
        {
            P2movementY--;
        }
    }
