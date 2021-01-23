cs
[ComImport]
[Guid("A65B8071-3BFE-4213-9A5B-491DA4461CA7")]
public class DxDiagProvider { }
[Guid("9C6B4CB0-23F8-49CC-A3ED-45A55000A6D2")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IDxDiagProvider
{
    void Initialize(ref DXDIAG_INIT_PARAMS pParams);
    void GetRootContainer(out IDxDiagContainer ppInstance);
}
[StructLayout(LayoutKind.Sequential)]
public struct DXDIAG_INIT_PARAMS
{
    public int dwSize;
    public uint dwDxDiagHeaderVersion;
    public bool bAllowWHQLChecks;
    public IntPtr pReserved;
};
You also need to wrap the `IDxDiagContainer` class:
cs
[Guid("7D0F462F-4064-4862-BC7F-933E5058C10F")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IDxDiagContainer
{
    void EnumChildContainerNames(uint dwIndex, string pwszContainer, uint cchContainer);
    void EnumPropNames(uint dwIndex, string pwszPropName, uint cchPropName);
    void GetChildContainer(string pwszContainer, out IDxDiagContainer ppInstance);
    void GetNumberOfChildContainers(out uint pdwCount);
    void GetNumberOfProps(out uint pdwCount);
    void GetProp(string pwszPropName, out object pvarProp);
}
Now we get to use our wrappers and have to do the following to retrieve the version info:
- Instantiate the provider by creating the coclass and casting it to the interface.
- Initialize the provider with the initialization parameters.
- Get the root container.
- Get the **DxDiag_SystemInfo** child container.
- Read the DirectX version properties.
Code which properly cleans up the COM resources can look like this:
cs
IDxDiagProvider provider = null;
IDxDiagContainer rootContainer = null;
IDxDiagContainer systemInfoContainer = null;
try
{
    // Instantiate and initialize the provider.
    provider = (IDxDiagProvider)new DxDiagProvider();
    DXDIAG_INIT_PARAMS initParams = new DXDIAG_INIT_PARAMS
    {
        dwSize = Marshal.SizeOf<DXDIAG_INIT_PARAMS>(),
        dwDxDiagHeaderVersion = 111
    };
    provider.Initialize(ref initParams);
    // Get the Root\SystemInfo container.
    provider.GetRootContainer(out rootContainer);
    rootContainer.GetChildContainer("DxDiag_SystemInfo", out systemInfoContainer);
    // Read the DirectX version info.
    int versionMajor = GetProperty<int>(container, "dwDirectXVersionMajor");
    int versionMinor = GetProperty<int>(container, "dwDirectXVersionMinor");
    string versionLetter = GetProperty<string>(container, "szDirectXVersionLetter");
    bool isDebug = GetProperty<bool>(container, "bDebug");
}
finally
{
    if (provider != null)
        Marshal.ReleaseComObject(provider);
    if (rootContainer != null)
        Marshal.ReleaseComObject(rootContainer);
    if (systemInfoContainer != null)
        Marshal.ReleaseComObject(systemInfoContainer);
}
As you can see there's a small utility `GetProperty` method I created to retrieve a correctly typed property from the `VARIANT` values the COM interface returns:
cs
private static T GetProperty<T>(IDxDiagContainer container, string propName)
{
    container.GetProp(propName, out object variant);
    return (T)Convert.ChangeType(variant, typeof(T));
}
