    string path = RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.User);
    using (RasPhoneBook pbk = new RasPhoneBook()) 
    {
        pbk.Open(path);
        // Find the device that will be used to dial the connection.
        RasDevice device = RasDevice.GetDevices().Where(o => o.Name == "Your Modem Name" && o.DeviceType == RasDeviceType.Modem).First();
        RasEntry entry = RasEntry.CreateDialUpEntry("Your Entry", "5555551234", device);
        // Configure any options for your entry here via entry.Options
        pbk.Entries.Add(entry);
    }
