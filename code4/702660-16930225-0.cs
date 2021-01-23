    public class Manager
    {
        public static Task<CutSheet.CutSheet> GetCutSheetAsync(IElevation elevation)
        {
            return CutSheet.Manager.GetCutSheetAsync(elevation);
        }
    }
