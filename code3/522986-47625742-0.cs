     [SecurityCritical]
        private static bool InternalExistsHelper(string path, bool checkHost)
        {
          try
          {
            if (path == null || path.Length == 0)
              return false;
            path = Path.GetFullPathInternal(path);
            if (path.Length > 0 && Path.IsDirectorySeparator(path[path.Length - 1]))
              return false;
            FileIOPermission.QuickDemand(FileIOPermissionAccess.Read, path, false, false);
            return File.InternalExists(path);
          }
          catch (ArgumentException ex)
          {
          }
          catch (NotSupportedException ex)
          {
          }
          catch (SecurityException ex)
          {
          }
          catch (IOException ex)
          {
          }
          catch (UnauthorizedAccessException ex)
          {
          }
          return false;
        }
