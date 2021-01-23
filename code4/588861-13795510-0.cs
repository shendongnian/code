    private const string CLSID_FIREWALL_MANAGER = "{304CE942-6E39-40D8-943A-B913C40C9CD4}"; //This is the CLSID of Home Networking Configuration Manager. We'll use this to detect whether the Firewall is enabled or not
    private static NetFwTypeLib.INetFwMgr GetHNCMType()
    {
        Type objectType = Type.GetTypeFromCLSID(new Guid(CLSID_FIREWALL_MANAGER)); //Creates a new GUID from CLSID_FIREWALL_MANAGER getting its type as objectType
        return Activator.CreateInstance(objectType) as NetFwTypeLib.INetFwMgr; //Creates an instance from the object type we gathered as an INetFwMgr object
    }
    static void Main(string[] args)
    {
        INetFwMgr manager = GetHNCMType(); //Initializes a new INetFwMgr of name manager from GetHNCMType
        if (manager.LocalPolicy.CurrentProfile.FirewallEnabled == false) //Continue if the firewall is not enabled
        {
            //The firewall is not enabled
            Console.WriteLine("OFF"); //Writes OFF to the Console in a new line
        }
        else //Otherwise:
        {
            //The fire wall is enabled
            Console.WriteLine("ON"); //Writes ON to the Console in a new line
        }
    }
