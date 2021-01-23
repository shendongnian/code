    string backup = source + ".bak";
    File.Delete(backup);
    File.Replace(source, destination, backup, true);
    try {
        File.Delete(backup);
    }
    catch {
        // optional:
        filesToDeleteLater.Add(backup);
    }
