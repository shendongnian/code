    public static T Generate<T>(T input)
        where T : Operation // ALLOWS BinaryOperation - NOT WANT THIS
    {
        // Checks to see if it is "Operation" (and not derived type)
        if (input.GetType() != typeof(Operation))
        {
            // Handle bad case here...
        }
        // Alternatively, if you only want to not allow "BinaryOperation", you can do:
        if (input is BinaryOperation)
        {
            // Handle "bad" case of a BinaryOperation passed in here...
        }
    }
