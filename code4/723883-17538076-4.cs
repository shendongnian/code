        static public TOutClass CommonFunc<TOutClass>(Func<Manager, TOutClass> func)
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
                TOutClass output = func(dm);
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
