        static public OutClass CommonFunc(Func<Manager, OutClass> func)
        {
            if (IsDebugEnabled)
            {
                Logger("Start DataLibrary: FUNC-X");
            }
            try
            {
                CheckInitSucceeded();
                GetAuthenticationTokens();
                var dm = new Manager();
                OutClass output = func(dm);
                if (IsDebugEnabled)
                {
                    var data = Serialize(output);
                    Logger(output);
                }
                return output;
            }
            catch
                [...]
        }
