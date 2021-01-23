      public UObject()       
        {
            // this is necessary otherwise EF will throw null object reference error. you could also put ?? operator check for more interactive solution.  
            UObjects = new List<UObject>(); 
        }
