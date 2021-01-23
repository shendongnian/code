    /// <summary>
    /// Determines if a nullable Guid (Guid?) is null or Guid.Empty
    /// </summary>
    public static bool IsNullOrEmpty(this Guid? guid)
    {
      return (!guid.HasValue || guid.Value == Guid.Empty);
    }
