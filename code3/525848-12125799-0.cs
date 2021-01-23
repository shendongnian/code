    In the base class:
    #if DEBUG
       [DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
       internal const System.Diagnostics.DebuggerBrowsableState BROWSABLE_ATTRIB = System.Diagnostics.DebuggerBrowsableState.Collapsed;
    #else
       [DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
       internal const System.Diagnostics.DebuggerBrowsableState BROWSABLE_ATTRIB = System.Diagnostics.DebuggerBrowsableState.Never;
    #endif
