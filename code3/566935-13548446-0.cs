    // An additional constructor
    public ImageAndTextCell (IntPtr handle)
        : base(handle)
    {
    }
    // Cocoa Selectors
    static IntPtr selRetainCount = Selector.GetHandle("retainCount");
    static IntPtr selCopyWithZone = Selector.GetHandle("copyWithZone:");
    
    static List<ImageAndTextCell> _refPool = new List<ImageAndTextCell>();
    // Helper method to be called at some future point in managed code to release
    // managed instances that are no longer needed.
    public void PeriodicCleanup ()
    {
        List<ImageAndTextCell> markedForDelete = new List<ImageAndTextCell> ();
    
        foreach (ImageAndTextCell cell in _refPool) {
            uint count = Messaging.UInt32_objc_msgSend (cell.Handle, selRetainCount);
            if (count == 1)
                markedForDelete.Add (cell);
        }
    
        foreach (ImageAndTextCell cell in markedForDelete) {
            _refPool.Remove (cell);
            cell.Dispose ();
        }
    }
    // Overriding the copy method
    [Export("copyWithZone:")]
    public virtual NSObject CopyWithZone(IntPtr zone) {
        IntPtr copyHandle = Messaging.IntPtr_objc_msgSendSuper_IntPtr(SuperHandle, selCopyWithZone, zone);
        ImageAndTextCell cell = new ImageAndTextCell(copyHandle) {
            Image = Image,
        };
    
        _refPool.Add(cell);
    
        return cell;
    }
