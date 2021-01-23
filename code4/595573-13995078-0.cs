    public interface IAccessRights
    {
      Bool CanReadFromDisk { get; }
      Bool CanWriteToDisk { get; };
      Bool CanAccessNetwork { get; }
    }
