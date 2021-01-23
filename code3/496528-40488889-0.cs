        public void HandleException(Exception ex, [CallerMemberName] string caller = "")
        {
            if (ex != null)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;
                foreach (var method in new StackTrace().GetFrames())
                {
                    if (method.GetMethod().Name == caller)
                    {
                        caller = $"{method.GetMethod().ReflectedType.Name}.{caller}";
                        break;
                    }
                }
                Console.WriteLine($"Exception: {ex.Message} Caller: {caller}()");
            }
        }
