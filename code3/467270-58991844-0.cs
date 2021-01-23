csharp
/// <summary>
/// Returns an unique absolute path based on the input absolute path.
/// <para>It adds suffix to file name if the input folder already has the file with the same name.</para>
/// </summary>
/// <param name="absolutePath">An valid absolute path to some file.</param>
/// <param name="getIndex">A suffix function which is added to original file name. The default value: " (n)"</param>
/// <returns>An unique absolute path. The suffix is used when necessary.</returns>
public static string GenerateUniqueAbsolutePath(string absolutePath, Func<UInt64, string>? getIndex = null)
{
    if (getIndex == null)
    {
        getIndex = i => $" ({i})";
    }
    // ... other logic
}
