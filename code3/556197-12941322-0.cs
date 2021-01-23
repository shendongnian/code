    static readonly IntPtr class_ptr = Class.GetHandle(typeof(BackButton));
    public new static BackButtonAppearance Appearance
    {
        get {
            return new BackButtonAppearance (Messaging.IntPtr_objc_msgSend (class_ptr, UIAppearance.SelectorAppearance));
        }
    }
    public new static BackButtonAppearance AppearanceWhenContainedIn (params Type[] containers)
    {
        return new BackButtonAppearance (UIAppearance.GetAppearance (class_ptr, containers));
    }
