        class Thing
        {
            public void UpdateState(/* parameters */)
            {
                // Update field/property values, etc.
            }
        }
        ...        
        foreach (var thing in things)
            thing.UpdateState(/* new values */);
