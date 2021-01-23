    using Microsoft.Win32;
    ...
    //Where CardInformation is some data structure to hold the information.
    public static IEnumerable<CardInformation> GetCardInformation()
    {
        string cardsKeyAddress =  "\SYSTEM\CurrentControlSet\Control\Class\{4D36E972-E325-11CE-BFC1-08002BE10318}";
        RegistryKey cardsKey = Registry.LocalMachine.OpenSubKey(cardsKeyAddress);
        string[] cardNumbers = cardsKey.GetSubKeyNames();
    
        foreach(string n in cardNumbers)
            yield return LoadCardInformation(cardsKeyAddress+"\\"+n);
    }
    static CardInformation LoadCardInformation(string key)
    {
        //Get whatever values from the key to return
        CardInfomation info = new CardInformation();
        info.Name = Registry.GetValue(key, "Name", "Unnamed");
        return info;
    }
