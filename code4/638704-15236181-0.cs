    public IJavaObject ToJavaObject()
    {
        // Snip
        return new Java.Lang.Object(result, JniHandleOwnership.DoNotTransfer);
    }
    public static IJavaObject ConvertArrayToJavaObject(B[] arr)
    {
        // Snip
        return Java.Lang.Object.FromArray<IJavaObject>(tempCopy);
    }
