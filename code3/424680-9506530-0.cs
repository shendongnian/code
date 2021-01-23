    public static bool IsPatchAlreadyInstalled(string productCode, string patchCode)
    {
        var patches = 
            PatchInstallation.GetPatches(null, productCode, null, UserContexts.Machine, PatchStates.Applied);
    
        return patches.Any(patch => patch.DisplayName == patchCode);
    }
