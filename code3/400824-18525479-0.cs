        public static bool ToggleIDNIRISupport(bool enable)
        {
            //Important: Try IsWellFormedUriString() once to initialize static fields: s_IdnScope, s_IriParsing
            Uri.IsWellFormedUriString("http://example.com/query=ü", UriKind.Absolute);
            //Get the assembly that contains the class
            Assembly assembly = Assembly.GetAssembly(typeof(Uri));
            if (assembly != null)
            {
                //Use the assembly in order to get the type of the class
                Type uriType = assembly.GetType("System.Uri");
                if (uriType != null)
                {
                    object idnScope = uriType.InvokeMember("s_IdnScope", BindingFlags.Static | BindingFlags.GetField | BindingFlags.NonPublic, null, null, new object[] { });
                    if (idnScope != null)
                    {
                        if (enable)
                        {
                            uriType.InvokeMember("s_IdnScope", BindingFlags.Static | BindingFlags.SetField | BindingFlags.NonPublic, null, null, new object[] { UriIdnScope.All });
                        }
                        else
                        {
                            uriType.InvokeMember("s_IdnScope", BindingFlags.Static | BindingFlags.SetField | BindingFlags.NonPublic, null, null, new object[] { UriIdnScope.None });
                        }
                    }
                    object iriParsing = uriType.InvokeMember("s_IriParsing", BindingFlags.Static | BindingFlags.GetField | BindingFlags.NonPublic, null, null, new object[] { });
                    if (iriParsing != null)
                    {
                        uriType.InvokeMember("s_IriParsing", BindingFlags.Static | BindingFlags.SetField | BindingFlags.NonPublic, null, null, new object[] { enable });
                    }
                }
            }
            return true;
        }
