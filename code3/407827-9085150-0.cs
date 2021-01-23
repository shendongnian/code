    public static void ManagedSendKeys(string keys)
            {
                SendKeys.SendWait(keys);
                SendKeys.Flush();
            }
