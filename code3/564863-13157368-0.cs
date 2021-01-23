    public class StrongFileType
    {
        private string _friendlyName = string.Empty;
        public StrongFileType(string friendlyName)
        {
            _friendlyName = friendlyName;
        }
        public IEnumerable<StrongFileType> CompatibleTypes { get; set; }
        public override string ToString()
        {
            return _friendlyName;
        }
    }
    private void SampleTest()
    {
        // The possible types
        var typeA = new StrongFileType("A");
        var typeB = new StrongFileType("B");
        var typeC = new StrongFileType("C");
        var typeD = new StrongFileType("D");
        var typeE = new StrongFileType("E");
            
        // Setup possible compatible types
        typeA.CompatibleTypes = new List<StrongFileType> { typeA, typeB, typeC, typeD };
        typeB.CompatibleTypes = new List<StrongFileType> { typeA, typeB, typeC };
        typeC.CompatibleTypes = new List<StrongFileType> { typeA, typeB, typeC, typeD };
        typeD.CompatibleTypes = new List<StrongFileType> { typeA, typeC, typeD, typeE };
        typeE.CompatibleTypes = new List<StrongFileType> { typeD, typeE };
        // Now do a check...
        var userSubmittedFilesValid = new List<StrongFileType> { typeA, typeB, typeC };
        CheckCompatible(userSubmittedFilesValid);
        var userSubmittedFilesInvalid = new List<StrongFileType> { typeA, typeB, typeC, typeD };
        CheckCompatible(userSubmittedFilesInvalid);
    }
    private bool CheckCompatible(IEnumerable<StrongFileType> requestedFiles)
    {
        // Useful for debugging
        var validList = new List<string>();
        var invalidList = new List<string>();
        foreach (StrongFileType fileType in requestedFiles)
        {
            string invalid = string.Empty;
            string validCombination = string.Empty;
            foreach (StrongFileType fileTypeToCheck in requestedFiles)
            {
                if (!fileType.CompatibleTypes.Contains(fileTypeToCheck))
                {
                    // Show as not compatible and remove any previously valid combinations that match
                    invalid += string.Format("{0} not compatible with {1}", fileType, fileTypeToCheck);
                    validList.RemoveAll(x => x.Contains(fileType.ToString()) && x.Contains(fileTypeToCheck.ToString()));
                }
                else
                {
                    validCombination += string.Format("{0}", fileTypeToCheck);
                }
            }
            // Add to respective lists
            if (!string.IsNullOrEmpty(validCombination) && !validList.Contains(validCombination))
            {
                validList.Add(validCombination);
            }
            if (!string.IsNullOrEmpty(invalid))
            {
                invalidList.Add(invalid);
            }
        }
        // Was valid?
        return invalidList.Count == 0;
    }
