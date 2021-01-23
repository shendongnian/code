        lock(instance)
        {
            if (instance.Contains(1))
            {
                continue;
            }    // **thread switch maybe happens here will cause your problem** 
            else
            {
                instance.AddNew(1);
            }
        }
