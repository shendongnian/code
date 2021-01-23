            private static string GetCurrentUserName()
            {
              string[] pathParts = Thread.CurrentPrincipal.Identity.Name.Split('\\');
                if (pathParts.Length != 0)
                {
                    return pathParts[pathParts.Length - 1];
                }
    
                return string.Empty;
            }
