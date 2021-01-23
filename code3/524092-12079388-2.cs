    var vcf = await KnownFolders.DocumentsLibrary.GetFileAsync("TestCard.vcf");
    var vcfBytes = await FileIO.ReadBufferAsync(vcf);
    var vcfCopy = await KnownFolders.DocumentsLibrary.CreateFileAsync("TestCard - copy.vcf");
    CachedFileManager.DeferUpdates(vcfCopy);
    await FileIO.WriteBufferAsync(vcfCopy, vcfBytes);
    await CachedFileManager.CompleteUpdatesAsync(vcfCopy);
    Launcher.LaunchFileAsync(vcfCopy, new LauncherOptions { DisplayApplicationPicker = true });
