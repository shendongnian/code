    // ...Service operation code impersonating a client here
    
    using (WindowsImpersonationContext processContext = WindowsIdentity.Impersonate(IntPtr.Zero))
    {
    	// Database access stuff here
    	// Within the using block the client is no longer impersonated:
    	// context reverts to the identity running the service host process
        // (I'm assuming this is what you call your service account)
    }
    
    // Ensuing code impersonates the client as previously...
