    using Microsoft.Win32;
    namespace MySpace
    {
        public class Setup
        {
            public Setup()
            {
                SetUpEnvironment();
            }
            private void SetUpEnvironment()
            {
                string test_a = Environment.GetEnvironmentVariable("SYSTEMDRIVE", EnvironmentVariableTarget.Process);
                string test_b = Environment.GetEnvironmentVariable("SYSTEMROOT", EnvironmentVariableTarget.Process);
                if (test_a == null || test_a.Length == 0 || test_b == null || test_b.Length == 0)
                {
                    string RegistryPath = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion";
                    string SYSTEMROOT = (string) Registry.GetValue(RegistryPath, "SystemRoot", null);
                    if (SYSTEMROOT == null)
                    {
                        throw new System.ApplicationException("Cannot access registry key " + RegistryPath);
                    }
                    string SYSTEMDRIVE = SYSTEMROOT.Substring(0, SYSTEMROOT.IndexOf(':') + 1);
                    Environment.SetEnvironmentVariable("SYSTEMROOT", SYSTEMROOT, EnvironmentVariableTarget.Process);
                    Environment.SetEnvironmentVariable("SYSTEMDRIVE", SYSTEMDRIVE, EnvironmentVariableTarget.Process);
                }
            }
        }
    }
