    using System;
    using System.Collections.Generic;
    using System.Management;
    using System.Text;
    
    namespace GetWMI_Info
    {
        public class InvokeAsync
        {
            public InvokeAsync()
            {
    
                // Create a results watcher object,
                ManagementOperationObserver results = new ManagementOperationObserver();
    
                // Attach handler to events for results and completion
                results.ObjectReady += new ObjectReadyEventHandler(this.NewObject);
                results.Completed += new CompletedEventHandler(this.Done);
    
                ManagementScope Scope;
                Scope = new ManagementScope("\\\\.\\root\\CIMV2", null);
    
                Scope.Connect();
                ObjectGetOptions Options = new ObjectGetOptions();
                ManagementPath Path = new ManagementPath("Win32_Volume.DeviceID=\"\\\\\\\\?\\\\Volume{178edf63-2039-11e2-8012-005056c00008}\\\\\"");
                ManagementObject ClassInstance = new ManagementObject(Scope, Path, Options);
                ManagementBaseObject inParams = ClassInstance.GetMethodParameters("Format");
    
    
                ClassInstance.InvokeMethod(results, "Format", inParams, null);
    
                while (!this.Completed)
                {
                    System.Threading.Thread.Sleep(1000);
                }
    
                this.Reset();
    
            }
    
            private bool isCompleted = false;
    
            private void NewObject(object sender,
                ObjectReadyEventArgs obj)
            {
                Console.WriteLine("ReturnValue : {0}", obj.NewObject["ReturnValue"]);
            }
    
            private bool Completed
            {
                get
                {
                    return isCompleted;
                }
            }
    
            private void Reset()
            {
                isCompleted = false;
            }
    
            private void Done(object sender,
                CompletedEventArgs obj)
            {
                isCompleted = true;
            }
    
            public static void Main()
            {
                InvokeAsync example =
                    new InvokeAsync();
    
                return;
            }
    
        }
    }
