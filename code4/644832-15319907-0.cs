    public static class CarExtensionMethods
    {
        public static string Message(this CarStates value)
        {
            return carStateDictionary[value];
        }
       
        private static readonly Dictionary<CarStates, string> carStateDictionary;
        static CarExtensionMethods()
        {
            carStateDictionary = new Dictionary<CarStates, string>();
            carStateDictionary.Add(CarStates.Off, "Car is off.");
            carStateDictionary.Add(CarStates.Idle, "Car is idling.");
            carStateDictionary.Add(CarStates.Drive, "Car is driving.");
            carStateDictionary.Add(CarStates.Accident, "CRASH!");
        }
    }
