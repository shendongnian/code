    /// <summary>
    /// Computes an incremental value between every adjacent element in a sequence: {N,N+1}, {N+1,N+2}, ...
    /// </summary>
    /// <remarks>
    /// The projection function is passed the previous and next element (in that order) and may use
    /// either or both in computing the result.<
    /// If the sequence has less than two items, the result is always an empty sequence.
    /// The number of items in the resulting sequence is always one less than in the source sequence.
    /// </remarks>
