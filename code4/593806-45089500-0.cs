    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    // #define DEBUG
    
    namespace ProcessRealtime
    {
        class PUBG_RealTime
        {
    		static string processName = "TslGame";
    		static ProcessPriorityClass newPriority = ProcessPriorityClass.High;
    		
            static void Main(string[] args)
            {
    #if DEBUG
    			PutDebug("Start!");
    #endif
                Process[] processes = Process.GetProcessesByName(processName);
    #if DEBUG
    			PutDebug(processes.Length + " processed found");
    #endif
                foreach (Process proc in processes)
                {
    #if DEBUG
    				PutDebug("New process found");
    #endif
                    Console.WriteLine("Changing Priority for id:" + proc.Id + " to " + newPriority.ToString());
                    proc.PriorityClass = newPriority;
    #if DEBUG
    				PutDebug("Changed priority for " + proc.Id);
    #endif
                }
    #if DEBUG
    			PutDebug("No more processes..");
    #endif
    			Console.Write("Press a key, it's over !");
                Console.ReadLine();
            }
    
    #if DEBUG
    		static bool debug = true;
    		static int debugInc = 1;
    		static void PutDebug(string info = "")
    		{
    			if(debug){
    				Console.WriteLine("Debug" + debugInc + ": " + info);
    				debugInc++;
    			}
    		}
    #endif
        }
    }
