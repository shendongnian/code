    public IList<OverallEvent> GetEvents() {
        using (var context = new AssessmentSystemContext()) {
            context.Configuration.LazyLoadingEnabled = false;
            return ...
        }
    }
