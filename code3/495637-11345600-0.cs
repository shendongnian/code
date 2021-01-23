    public static readonly bool MaximumRecipientsReached = false;
    public readonly bool MyInstanceReadonly = false;
    static AdditionalRecipient()
    {
        // static readonly can only be altered in static constructor
        MaximumRecipientsReached = true; 
    }
    public AdditionalRecipient()
    {
        // instance readonly can be altered in instance constructor
        MyInstanceReadonly = true;  
    }
