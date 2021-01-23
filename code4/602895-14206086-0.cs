        // Extract invocation list and call recursive dispatch:
        RecursiveDispatch(0, myEvent.GetInvocationList(), arguments);
        private static void RecursiveDispatch(int index, Delegate[] delegates, object[] arguments)
        {
            if (delegates == null || index >= delegates.Length)
                return;
            try
            {
                delegates[index].DynamicInvoke(arguments);
            }
            catch
            {
                InternalInvoke(index + 1, delegates, arguments);
                throw;
            }
            InternalInvoke(index + 1, delegates, arguments);
        }
