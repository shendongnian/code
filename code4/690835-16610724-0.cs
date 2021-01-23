    private static Dictionary<string, Gamme> userGammes;
    public static Dictionary<string, Gamme> UserGammes
    {
        get 
        {
           if (userGammes== null)
           {
              userGammes = new Dictionary<string, Gamme>();
           }
           return userGammes;
        }
    }
