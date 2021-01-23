    public class PatientDxService
    {
        private readonly ISessionManager _session;
        public PatientDxService(ISessionManager session)
        {
            this._session = session;
        }
        public void DoStuff()
        {
            var patient = _session.GetPatient();
            ...
        }
    }
