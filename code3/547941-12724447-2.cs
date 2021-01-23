public Interface IDisplayInfo
{
    void GetInfo();
}
public class Atom : IDisplayInfo
{
    public void GetInfo()
    {
        ...
    }
}
public class Electron : IDisplayInfo
{
    public void GetInfo()
    {
        ...
    }
}
