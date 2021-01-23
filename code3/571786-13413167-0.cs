    /// <p/>Note that each term in the document can be no longer
    /// than 16383 characters, otherwise an
    /// IllegalArgumentException will be thrown.<p/>
    // [...]
	
    /// <summary> Absolute hard maximum length for a term.  If a term
    /// arrives from the analyzer longer than this length, it
    /// is skipped and a message is printed to infoStream, if
    /// set (see <see cref="SetInfoStream" />).
    /// </summary>
    public static readonly int MAX_TERM_LENGTH;
