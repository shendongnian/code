    public class Program {
        static void Main() {
            if (Array.IndexOf(Environment.GetCommandLineArgs(), "/unlocked") == -1) {
                // We have not been launched by ourself! Copy the assembly to a temp location
                // so the user can delete our original location.
                string temp_location = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Path.GetFileName(Application.ExecutablePath));
                File.Copy(Application.ExecutablePath, temp_location);
                Process proc = new Process();
                proc.StartInfo.FileName = temp_location;
                proc.StartInfo.Arguments = "/unlocked";
                proc.Start();
                // no more work in main, so application closes...
            } else {
                // else initialize application as normal...
            }
        }
    }
