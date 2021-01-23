    using System.Collections.ObjectModel;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    using System.Text;
    
    namespace admin_scripts {
      public class PSHelper {
        // See the _ps_user_lookup method for demonstration of using this method
        public static Runspace new_runspace() {
          InitialSessionState init_state = InitialSessionState.CreateDefault();
          init_state.ThreadOptions = PSThreadOptions.UseCurrentThread;
          init_state.ImportPSModule(new[] { "ActiveDirectory", "C:\\ps_modules\\disable_user.psm1" });
          return RunspaceFactory.CreateRunspace(init_state);
        }
    
        // This method is for dead-simple scripts that you only want text output from
        public static string run_simple_script( string body ) {
          Runspace runspace = new_runspace();
          runspace.Open();
    
          Pipeline pipeline = runspace.CreatePipeline();
          pipeline.Commands.AddScript(body);
          pipeline.Commands.Add("Out-String");
    
          Collection<PSObject> output = pipeline.Invoke();
          runspace.Close();
    
          StringBuilder sb = new StringBuilder();
          foreach( PSObject line in output ) {
            sb.AppendLine(line.ToString());
          }
          return sb.ToString();
        }
      }
    }
