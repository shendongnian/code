    public static async Task<List<string>> GetMammalDeviceID(string mammalID, string zoologistDeviceID)
    {
        IMobileServiceTable<DUCKBILLED_PLATYPI> table = App.MobileService.GetTable<DUCKBILLED_PLATYPI>();
    
        MobileServiceTableQuery<String> query =
            table.Where(i => i.mammalID == mammalID).
                  Where(j => j.zoologistDeviceID == zoologistDeviceID).
                  Select(k => k.mammalDeviceID);
        return await query.ToListAsync()
    }
