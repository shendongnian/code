    public byte B
    {
      [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")] get
      {
        return (byte) ((ulong) this.Value & (ulong) byte.MaxValue);
      }
    }
