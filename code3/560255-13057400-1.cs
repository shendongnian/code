    internal class FakeCaptionSummary : ICustomSummaryCalculator
    {
        public FakeCaptionSummary()
        {
             // Empty constructor
        }
        // Called at the start of the custom summary calculation
        public void BeginCustomSummary(SummarySettings summarySettings, RowsCollection rows)
        {}
        // Called for each row in band of this summary
        public void AggregateCustomSummary(SummarySettings summarySettings, UltraGridRow row)
        {}
        // Called to get the return value to put in the SummaryRpw at the specified column
        public object EndCustomSummary(SummarySettings summarySettings, RowsCollection rows)
        {
            return "";
        }
    }
