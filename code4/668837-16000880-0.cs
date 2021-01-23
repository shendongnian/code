    public static DriverBase CreateDriver(string identifier, object device) {
        switch (identifier) {
        case IDENTIFIER_A: return new ConcreteDeviceA(device);
        // etc
        }
    }
