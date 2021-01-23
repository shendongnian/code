      public UObject()       
        {
            // this is necessary otherwise EF will throw null object reference error. You could also put ?? operator check for a more interactive solution.  
            UObjects = new List<UObject>(); 
        }
