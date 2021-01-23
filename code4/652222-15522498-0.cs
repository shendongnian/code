    public static class ProfilingHelpers
    {
        [Conditional("PROFILE")]
        public static void StartProfiling()
        {
            DataCollection.StartProfile(ProfileLevel.Process, DataCollection.CurrentId);
        }
    }
