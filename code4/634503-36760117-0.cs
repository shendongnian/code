    using System;
    using System.DirectoryServices;
    using System.Collections;
    
    namespace IISHandlerMappingsRevertToParentAll
    {
        class Program
        {
            static void Main(string[] args)
            {
                if (args == null || args.Length != 3)
                {
                    Console.WriteLine("IISHandlerMappingsRevertToParentAll.exe WebServer UserName Password");
                    Console.WriteLine("Example: IISHandlerMappingsRevertToParentAll WebServer1 WebServer1\\MyUserName MyPassword");
                }
                else
                {
                    DateTime dt = DateTime.Now;
                    int cleared = 0;
                    using (DirectoryEntry root = new DirectoryEntry("IIS://" + args[0] + "/W3SVC", args[1], args[2], AuthenticationTypes.FastBind))
                    {
                        foreach (DirectoryEntry r in root.Children)
                        {
                            if (r.SchemaClassName == "IIsWebServer")
                            {
                                foreach (DirectoryEntry e in r.Children)
                                {
                                    if (e.SchemaClassName == "IIsWebVirtualDir")
                                    {
                                        ArrayList ScriptMaps = new ArrayList(e.Properties["ScriptMaps"]);
                                        if (ScriptMaps.Count > 0)
                                        {
                                            Console.WriteLine("Clearing for " + e.Properties["Path"].Value);
                                            cleared++;
                                            e.Properties["ScriptMaps"].Clear();
                                            root.CommitChanges();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    Console.WriteLine("Reset " + cleared + " took " + DateTime.Now.Subtract(dt).TotalSeconds + "s ");
                }
            }
        }
    }
