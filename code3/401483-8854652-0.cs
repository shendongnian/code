        static public bool IsLightFile(string fileName)
        {
            foreach (var eVal in Enum.GetNames(typeof(LightFiles)))
            {
                if (fileName.Contains(eVal))
                {
                    return true;
                }
            }
            return false;
        }
