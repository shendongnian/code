    public static List<string> Files = RealFile(true);
    private static List<string> RealFile(Boolean Reload=true)
    {
          if (!Reload)
              return Files;
          try
          {
              return Files;
          }
          catch (Exception) { return Files; }
    }
