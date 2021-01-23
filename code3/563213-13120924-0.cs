    public void TestUpdateList ( User user, Address addr )
        {
            // The param "addr" contains new values
            // These values must ALWAYS be placed in the first item
            // of the "Addresses" list.
    
            // Get the first Address object and overwrite that with
            // the new "addr" object
            user.Addresses[0] = addr; // <-- doesn't work, but should give you an idea
        }
