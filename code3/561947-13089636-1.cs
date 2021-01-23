    private void ThreadWork(object data) // executing in Thread2
    {
        // Thread2 running here
        SaveContainer sc = data as SaveContainer; // holds images
    
        bool[] blankIndex = new bool[sc.imagelist.Count]; // to use in Parallel.For loop
        for (int i = 0; i < sc.imagelist.Count; i++)
            blankIndex[i] = false; // set default value to false (not blank)
    
        // Thread2 blocks on this call
        Paralle.For(0, sc.imagelist.Count, i => // loop to mark blank images
        {
            // Thread from the pool is running here (NOT Thread2)!!!
    
            bool x = false; // local vars make loop more efficient
            x = sc.IsBlankImage((short)i); // check if image at index i is blank
            blankIndex[i] = x; // set if image is blank
        }
        // Thread2 resumes running here
    
        .... // other image processing steps
    }
