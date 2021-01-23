    [Flags()]
    public enum RunFileDialogFlags : uint
    {
        /// <summary>
        /// Don't use any of the flags (only works alone)
        /// </summary>
        None = 0x0000,    
        /// <summary>
        /// Removes the browse button
        /// </summary>
        NoBrowse = 0x0001,
    
        /// <summary>
        /// No default item selected
        /// </summary>
        NoDefault = 0x0002,
    
        /// <summary>
        /// Calculates the working directory from the file name
        /// </summary>
        CalcDirectory = 0x0004,
    
        /// <summary>
        /// Removes the edit box label
        /// </summary>
        NoLabel = 0x0008,
    
        /// <summary>
        /// Removes the separate memory space checkbox (Windows NT only)
        /// </summary>
        NoSeperateMemory = 0x0020
    }
