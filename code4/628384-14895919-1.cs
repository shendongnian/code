    public static class LegacyCode
    {
        public static void Initialize(int p1, string p2)
        {
            //some static state
        }
        public static void ChangeSettings(bool p3, double p4)
        {
            //some static state
        }
        public static void DoSomething(string someOtherParam)
        {
            //execute based on some static state
        }
    }
    public class LegacyCodeFacadeService
    {
        public void PerformLegacyCodeActivity(LegacyCodeState state, LegacyCodeParams legacyParams)
        {
            lock (_lockObject)
            {
                LegacyCode.Initialize(state.P1, state.P2);
                LegacyCode.ChangeSettings(state.P3, state.P4);
                LegacyCode.DoSomething(legacyParams.SomeOtherParam);
                //do something to reset state, perhaps
            }
        }
    }
