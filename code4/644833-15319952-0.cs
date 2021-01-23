    // sample test app
    class Program
    {
        static void Main(string[] args)
        {
            var carState = CarModeStates.Accident;
            // the call to get the meta data could and probably should be stored in a local variable
            Console.WriteLine(carState.GetMetaData().Message);
            Console.WriteLine(carState.GetMetaData().IsError);
            Console.WriteLine(carState.GetMetaData().IsUsingPetrol);
            Console.Read();
        }
    }
