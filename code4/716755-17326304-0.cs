    // (XNA probably has a built-in way to handle acceleration.)
    // (Doing it manually like this might be informative, but I doubt it's the best way.)
    Vector2 ballPosition; // (when the game starts, set this to where the ball should be)
    Vector2 ballVelocity;
    Vector2 ballAcceleration;
    
    ...
    void accelerometer_CurrentValueChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e) {
        var reading = e.SensorReading.Acceleration;
        // (below may need to be -reading.Z, or even another axis)
        acceleration = new Vector2(reading.Z, 0);
    }
    // (Call this at a consistent rate. I'm sure XNA has a way to do so.)
    void AdvanceGameState(TimeSpan period) {
        var t = period.TotalSeconds;
        ballPosition += ballVelocity * t + ballAcceleration * (t*t/2);
        ballVelocity += ballAcceleration * t;
        this.squarePosition = ballPosition;
    }
