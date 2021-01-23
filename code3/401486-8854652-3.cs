        static public bool IsLightFile(string fileName)
        {
            foreach (var eVal in Enum.GetNames(typeof(LightFiles)))
            {
                if (Path.GetExtension(fileName).Equals(eVal))
                {
                    return true;
                }
            }
            return false;
        }
