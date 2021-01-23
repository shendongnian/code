    // Internal methodtable used to instantiate the "canonical" methodtable for generic instantiations.
    // The name "__Canon" will never been seen by users but it will appear a lot in debugger stack traces
    // involving generics so it is kept deliberately short as to avoid being a nuisance.
    
    [Serializable]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [System.Runtime.InteropServices.ComVisible(true)]
    internal class __Canon
    {
    }
