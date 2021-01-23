    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Runtime.InteropServices;
    
    namespace Subfolders {
        static internal class Native {
            [DllImport ("Netapi32.dll", SetLastError = true)]
            internal static extern uint NetApiBufferFree (IntPtr buffer);
    
            [DllImport ("Netapi32.dll", CharSet = CharSet.Unicode)]
            internal static extern uint NetShareEnum (
                 string serverName,
                 int level,
                 ref IntPtr bufPtr,
                 uint prefmaxlen,
                 ref int entriesread,
                 ref int totalentries,
                 ref int resumeHandle
            );
    
            [DllImport ("MPR.dll", CharSet = CharSet.Auto)]
            internal static extern uint WNetEnumResource(IntPtr hEnum, ref int lpcCount, IntPtr lpBuffer, ref int lpBufferSize);
    
            [DllImport ("MPR.dll", CharSet = CharSet.Auto)]
            internal static extern uint WNetOpenEnum(ResourceScope dwScope, ResourceType dwType, ResourceUsage dwUsage,
                IntPtr lpNetResource, out IntPtr lphEnum);
    
            [DllImport ("MPR.dll", CharSet = CharSet.Auto)]
            internal static extern uint WNetCloseEnum(IntPtr hEnum);
    
            internal const uint MaxPreferredLength = 0xFFFFFFFF;
            internal const int NerrSuccess = 0;
            internal enum NetError : uint {
                NerrSuccess = 0,
                NerrBase = 2100,
                NerrUnknownDevDir = (NerrBase + 16),
                NerrDuplicateShare = (NerrBase + 18),
                NerrBufTooSmall = (NerrBase + 23),
            }
            internal enum ShareType : uint {
                StypeDisktree = 0,
                StypePrintq = 1,
                StypeDevice = 2,
                StypeIpc = 3,
                StypeSpecial = 0x80000000,
            }
            [StructLayout (LayoutKind.Sequential, CharSet = CharSet.Unicode)]
            public struct ShareInfo1 {
                public string shi1_netname;
                public uint shi1_type;
                public string shi1_remark;
                public ShareInfo1 (string sharename, uint sharetype, string remark) {
                    shi1_netname = sharename;
                    shi1_type = sharetype;
                    shi1_remark = remark;
                }
                public override string ToString () {
                    return shi1_netname;
                }
            }
            public enum ResourceScope: uint {
                ResourceConnected = 0x00000001,
                ResourceGlobalnet = 0x00000002,
                ResourceRemembered = 0x00000003,
                ResourceRecent = 0x00000004,
                ResourceContext = 0x00000005
            }
            public enum ResourceType: uint {
                ResourcetypeAny = 0x00000000,
                ResourcetypeDisk = 0x00000001,
                ResourcetypePrint = 0x00000002,
                ResourcetypeReserved = 0x00000008,
                ResourcetypeUnknown = 0xFFFFFFFF
            }
            public enum ResourceUsage: uint {
                ResourceusageConnectable = 0x00000001,
                ResourceusageContainer = 0x00000002,
                ResourceusageNolocaldevice = 0x00000004,
                ResourceusageSibling = 0x00000008,
                ResourceusageAttached = 0x00000010,
                ResourceusageAll = (ResourceusageConnectable | ResourceusageContainer | ResourceusageAttached),
                ResourceusageReserved = 0x80000000
            }
            public enum ResourceDisplaytype: uint {
                ResourcedisplaytypeGeneric = 0x00000000,
                ResourcedisplaytypeDomain = 0x00000001,
                ResourcedisplaytypeServer = 0x00000002,
                ResourcedisplaytypeShare = 0x00000003,
                ResourcedisplaytypeFile = 0x00000004,
                ResourcedisplaytypeGroup = 0x00000005,
                ResourcedisplaytypeNetwork = 0x00000006,
                ResourcedisplaytypeRoot = 0x00000007,
                ResourcedisplaytypeShareadmin = 0x00000008,
                ResourcedisplaytypeDirectory = 0x00000009,
                ResourcedisplaytypeTree = 0x0000000A,
                ResourcedisplaytypeNdscontainer = 0x0000000B
            }
            [StructLayout (LayoutKind.Sequential)]
            public struct NetResource {
                public ResourceScope dwScope;
                public ResourceType dwType;
                public ResourceDisplaytype dwDisplayType;
                public ResourceUsage dwUsage;
                [MarshalAs (UnmanagedType.LPTStr)]
                public string lpLocalName;
                [MarshalAs (UnmanagedType.LPTStr)]
                public string lpRemoteName;
                [MarshalAs (UnmanagedType.LPTStr)]
                public string lpComment;
                [MarshalAs (UnmanagedType.LPTStr)]
                public string lpProvider;
            }
        }
        class Program {
            static IEnumerable<string> GetShares(string computerName) {
                var resources = new List<string>();
                IntPtr hEnum = IntPtr.Zero, pResource = IntPtr.Zero;
                try {
                    var resource = new Native.NetResource();
                    int bufferSize = 163840;
                    resource.dwType = Native.ResourceType.ResourcetypeAny;
                    resource.dwScope = Native.ResourceScope.ResourceGlobalnet;
                    resource.dwUsage = Native.ResourceUsage.ResourceusageContainer;
                    resource.lpRemoteName = computerName;
                    pResource = Marshal.AllocHGlobal(Marshal.SizeOf(resource));
                    Marshal.StructureToPtr (resource, pResource, false);
                    uint status = Native.WNetOpenEnum (Native.ResourceScope.ResourceGlobalnet,
                                                       Native.ResourceType.ResourcetypeDisk,
                                                       0,
                                                       pResource,
                                                       out hEnum);
                    if (status != 0)
                        return resources;
    
                    int numberOfEntries = -1;
                    IntPtr pBuffer = Marshal.AllocHGlobal(bufferSize);
                    status = Native.WNetEnumResource (hEnum, ref numberOfEntries, pBuffer, ref bufferSize);
                    if (status == Native.NerrSuccess && numberOfEntries > 0) {
                        var ptr = pBuffer;
                        for (int i = 0; i < numberOfEntries; i++, ptr += Marshal.SizeOf(resource)) {
                            resource = (Native.NetResource)Marshal.PtrToStructure (ptr, typeof (Native.NetResource));
                            resources.Add (resource.lpRemoteName.StartsWith (computerName + '\\',
                                                                             StringComparison.OrdinalIgnoreCase)
                                               ? resource.lpRemoteName.Substring (computerName.Length + 1)
                                               : resource.lpRemoteName);
                        }
                    }
                } finally {
                    if (hEnum != IntPtr.Zero) {
                        Native.WNetCloseEnum (hEnum);
                    }
                    if (pResource != IntPtr.Zero) {
                        Marshal.FreeHGlobal(pResource);
                    }
                }
                return resources;
            }
    
            static IEnumerable<string> GetAllShares (string computerName) {
                var shares = new List<string> ();
                IntPtr bufPtr = IntPtr.Zero;
                int entriesread = 0;
                int totalentries = 0;
                int resumeHandle = 0;
                int nStructSize = Marshal.SizeOf (typeof (Native.ShareInfo1));
                try {
                    uint ret = Native.NetShareEnum (computerName, 1, ref bufPtr,
                        Native.MaxPreferredLength,
                        ref entriesread,
                        ref totalentries,
                        ref resumeHandle);
                    if (ret == (uint)Native.NetError.NerrSuccess) {
                        var currentPtr = bufPtr;
                        for (int i = 0; i < entriesread; i++) {
                            var shi1 = (Native.ShareInfo1)Marshal.PtrToStructure (currentPtr, typeof (Native.ShareInfo1));
                            if ((shi1.shi1_type & ~(uint)Native.ShareType.StypeSpecial) == (uint)Native.ShareType.StypeDisktree) {
                                shares.Add (shi1.shi1_netname);
                            }
                            currentPtr = new IntPtr (currentPtr.ToInt32 () + nStructSize);
                        }
                    }
                } finally {
                    if (bufPtr != IntPtr.Zero)
                        Native.NetApiBufferFree (bufPtr);
                }
                return shares;
            }
            static IEnumerable<string> GetSubdirectories (string root) {
                var dirInfo = new DirectoryInfo (root);
                return (from info in dirInfo.EnumerateDirectories () select info.Name).ToList();
            }
            static void Main () {
                var root = @"\\OK01\Users";
                Console.WriteLine ("Subdirectories of {0}:", root);
                foreach (var dir in GetSubdirectories (root)) {
                    Console.WriteLine (dir);
                }
    
                Console.WriteLine ();
                root = @"\\OK01\Users\Public";
                Console.WriteLine ("Subdirectories of {0}:", root);
                foreach (var dir in GetSubdirectories (root)) {
                    Console.WriteLine (dir);
                }
    
                Console.WriteLine ();
                root = @"\\OK01";
                Console.WriteLine ("All Shares of {0} (inclusive hidden):", root);
                foreach (var shareName in GetAllShares (root)) {
                    Console.WriteLine (shareName);
                }
    
                Console.WriteLine ();
                root = @"\\OK01";
                Console.WriteLine ("Shares of {0}:", root);
                foreach (var shareName in GetShares (root)) {
                    Console.WriteLine (shareName);
                }
            }
        }
    }
