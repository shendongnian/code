    public static bool GetIsInDesignMode(DependencyObject element)
    {
        if (element == null)
        {
            throw new ArgumentNullException("element");
        }
        bool flag = false;
        if (Application.Current.RootVisual != null)
        {
            flag = (bool) Application.Current.RootVisual.GetValue(IsInDesignModeProperty);
        }
        return flag;
    }
    public static bool IsInDesignTool
    {
        get
        {
            return isInDesignTool;
        }
        [SecurityCritical]
        set
        {
            isInDesignTool = value;
        }
    }
    internal static bool InternalIsInDesignMode
    {
        [CompilerGenerated]
        get
        {
            return <InternalIsInDesignMode>k__BackingField;
        }
        [CompilerGenerated]
        set
        {
            <InternalIsInDesignMode>k__BackingField = value;
        }
    }
 
 
 
 
