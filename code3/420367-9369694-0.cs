    public interface IRemoteControlGroup {
         List<string> GetInstances();
         void Stop(string instanceId);
         void Start(string instanceId);
         void GetPID(string instanceId);
    }
