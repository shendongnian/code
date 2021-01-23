    public class PatchHub : Hub
    {
        ISession _session;
        public PatchHub(ISession session)
        {
            _session = session;
        }
    
        public void RunPatch(string name)
        {
            PatchService.Run(_session, name);
        }
    }
