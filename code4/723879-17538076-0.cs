        static public OutClass CommonFunc(Func<OutClass> func)
        {
            if (IsDebugEnabled)
            {
                Logger("Start DataLibrary: FUNC-X");
            }
            try
            {
                CheckInitSucceeded();
                GetAuthenticationTokens();
                OutClass output = func();
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
