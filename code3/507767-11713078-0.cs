    public class Ide
    {        
        [DllImport("ole32.dll")]
        private static extern void CreateBindCtx(int reserved, out IBindCtx ppbc);
        
        [DllImport("ole32.dll")]
        private static extern void GetRunningObjectTable(int reserved, out IRunningObjectTable prot);
        public static DTE2 GetDte(string solutionName)
        {
            DTE2 dte = null;
            GetDte((displayName, x) =>
            {
                if (System.IO.Path.GetFileName(x.Solution.FullName).Contains(solutionName))
                {
                    dte = x;
                    return false; // we found it stop seraching
                }
                else
                {
                    return true; // continue searching
                }
            });
            return dte;
        }
        public static DTE2 GetDte(int processId)
        {
            DTE2 dte = null;
            GetDte((displayName, x) =>
            {
                if (displayName.Contains(processId.ToString()))
                {
                    dte = x;
                    return false; // stop searching we found matching dte
                }
                else
                {
                    return true; // continue searching
                }
            });
            return dte;
        }
        public static List<DTE2> GetAllDte()
        {
            List<DTE2> list = new List<DTE2>();
            GetDte((displayName, x) =>
            {
                list.Add(x);
                return true; // continue serching we want all dte's
            });
            return list;
        }
        private static void GetDte(Func<string, DTE2, bool> foo)
        {
            Dictionary<string, string> dtesProcessIds = new Dictionary<string, string>();
            //rot entry for visual studio running under current process.            
            IRunningObjectTable rot;
            GetRunningObjectTable(0, out rot);
            IEnumMoniker enumMoniker;
            rot.EnumRunning(out enumMoniker);
            enumMoniker.Reset();
            IntPtr fetched = IntPtr.Zero;
            IMoniker[] moniker = new IMoniker[1];
            while (enumMoniker.Next(1, moniker, fetched) == 0)
            {
                IBindCtx bindCtx;
                CreateBindCtx(0, out bindCtx);
                string displayName;
                moniker[0].GetDisplayName(bindCtx, null, out displayName);
                object comObject;
                rot.GetObject(moniker[0], out comObject);
                if (comObject != null)
                {
                    DTE2 dteCurrent = null;
                    try
                    {
                        dteCurrent = (EnvDTE80.DTE2)comObject;
                        // if solution is not open continue
                        // this will cause an exception if it is not open
                        var temp = dteCurrent.Solution.IsOpen;
                        string solName = dteCurrent.Solution.FullName;
                        // if there is an instance of visual studio with no solution open continue                        
                        if (string.IsNullOrEmpty(solName))
                        {
                            continue;
                        }
                        // avoid adding duplicate ide's
                        if (dtesProcessIds.ContainsKey(displayName) == false)
                        {
                            dtesProcessIds.Add(displayName, displayName);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    catch (System.Runtime.InteropServices.COMException e)
                    {
                        continue;
                    }
                    catch (Exception e)
                    {
                        continue;
                    }
                    if (dteCurrent != null)
                    {
                        var cont = foo(displayName, dteCurrent);
                        if (cont == false)
                            return;
                    }
                }
            }
        }
    }
