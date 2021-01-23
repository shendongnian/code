    static public bool IsLightFile(string fileName)
        {
          var extension = Path.GetExtension(fileName).Remove(0, 1);
          return Enum.GetNames(typeof(LightFiles)).Any(enumVal => string.Compare(enumVal, extension, true) == 0);
        }
