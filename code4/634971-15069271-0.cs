     public class DebugService : IDebugService
        {
            public void LaunchDebugger()
            {
                //TODO - write some code indicating that this 
                //process was bebugged. e.g. - mark a flag in DB or file
                Debugger.Launch();
            }
    
            public bool WasDebuggedLastTime()
            {
                //TODO - write code to check if this process was debugged
            }
    
        }
