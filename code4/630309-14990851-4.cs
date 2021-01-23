    public class PSHelper {
      public static Runspace new_runspace() {
        InitialSessionState init_state = InitialSessionState.CreateDefault();
        init_state.ThreadOptions = PSThreadOptions.UseCurrentThread;
        init_state.ImportPSModule(new[] { "ActiveDirectory" });
        return RunspaceFactory.CreateRunspace(init_state);
      }
    }
