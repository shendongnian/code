    // enum with meta data
    public enum CarModeStates
    {
        [CarStatus("Car is off."), IsError(false), IsUsingPetrol(false)]
        Off,
        [CarStatus("Car is idling."), IsError(false), IsUsingPetrol(true)]
        Idle,
        [CarStatus("Car is driving."), IsError(false), IsUsingPetrol(true)]
        Drive,
        [CarStatus("CRASH!"), IsError(true), IsUsingPetrol(false)]
        Accident
    }
