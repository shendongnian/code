    /// <summary>
    /// Test an archive for integrity/validity
    /// </summary>
    /// <param name="testData">Perform low level data Crc check</param>
    /// <returns>true if all tests pass, false otherwise</returns>
    /// <remarks>Testing will terminate on the first error found.</remarks>
    public bool TestArchive(bool testData)
    {
        return TestArchive(testData, TestStrategy.FindFirstError, null);
    }
