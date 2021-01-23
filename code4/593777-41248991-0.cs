    public static void EnsureApplicationResources() {
                if (Application.Current == null) {
                    // create the Application object
                    try {
                        new App() {
                            ShutdownMode = ShutdownMode.OnExplicitShutdown
                        };
                    }
                    catch (System.Exception ex) {
                        Debug.WriteLine(ex.ToString());
                    }
                }
            }
