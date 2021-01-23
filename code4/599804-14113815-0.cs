    bool isWritableAndFree = false;
    try {
        using (new FileStream(name, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
        {
            isWritableAndFree = true;
        }
    } catch { }
    return isWritableAndFree;
