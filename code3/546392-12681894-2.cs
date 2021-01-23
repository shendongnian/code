    string CastAndSerialize(ISomething somthing)
    {
        //castSomthing will be null if ISomthing was not a ConcreteType.    
        ConcreteType castSomthing = somthing as ConcreteType; 
        if(castSomthing != null)
        {
           return Utilities.Serialize<ConcreteType>(castSomthing );
        }
        else
        {
            return null; //Or whatever you want to use to represent that the cast failed.
        }
    }
