    public class LegacyCodeFacadeService
    {
        private LegacyCodeFacadeService() { }
        public static LegacyCodeFacadeService GetInstance()
        {
            //now we can change lifestyle management strategies later, if needed
            return new LegacyCodeFacadeService();
        }
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
