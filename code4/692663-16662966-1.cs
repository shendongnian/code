    public enum Area
    {
         Goldcoast,
         Melbourne,
         // ...
    }
    public static class AreaExtensions
    {  
        public static string Postfix(this Area area)
        {
            return AreaPostfixes.ResourceManager.GetString(area.ToString());
        }
    }
    // AreaPostfixes.resx
    Name       Value
    Goldcoast  QLD
    Melbourne  MEL
    // Usage
    public string GetPostfix(Area area)
    {
        return area.Postfix();
    }
