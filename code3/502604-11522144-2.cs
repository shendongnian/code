    static class Guard
    {
        public static void AgainstNulls(object parameter, string name = null)
        {
            if (parameter == null) 
                throw new ArgumentNullException(name ?? "guarded argument was null");
            Contract.EndContractBlock(); // If you use Code Contracts.
        }
    }
    Guard.AgainstNulls(parameter, "parameter");
