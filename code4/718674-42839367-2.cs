    public enum QualityPersonInfo
    {
        Ok = 0,
        [LocalizedDescription(nameof(QualityStrings.P1), typeof(QualityStrings))]
        Duplicate = 1,
        [LocalizedDescription(nameof(QualityStrings.P2), typeof(QualityStrings))]
        IdMissing = 2,
    }
