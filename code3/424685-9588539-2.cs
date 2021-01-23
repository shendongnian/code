    public static bool CheckForPatch()
    {
        return IsPatchAlreadyInstalled("KB2468871")
    }
    public static bool IsPatchAlreadyInstalled(string patchCode)
    {
        var patches = PatchInstallation.AllPatches.ToList();
        patches.ForEach(x => Console.WriteLine("--found patch {0} for {1}",x.DisplayName,x.ProductCode));
        return patches.Any(patch => patch.DisplayName == patchCode);
    }
