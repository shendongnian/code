    public class PatchHub : Hub
    {
        ISession _session;
        public PatchHub(ISession session)
        {
            _session = session;
        }
    
        public void RunPatch(string name)
        {
            ParchService.Run(_session, name);
        }
    }
