    /// <summary>
    /// Retrieves personal information about the person.
    /// </summary>
    /// <returns>
    /// A tuple containing the following information:
    /// <list type="bullet">
    /// <item><see cref="Tuple{T1,T2,T3}.Item1"/>: The name of the person.</item>
    /// <item><see cref="Tuple{T1,T2,T3}.Item2"/>: The age of the person.</item>
    /// <item><see cref="Tuple{T1,T2,T3}.Item3"/>: The number of fingers the person has.</item>
    /// </list>
    /// </returns>
    public Tuple<string, int, int> GetPerson()
    {
        return Tuple.Create("ABC", 33, 10);
    }
