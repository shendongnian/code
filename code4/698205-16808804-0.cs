    public IEnumerable<DeviceLog> GetRecent(DeviceLog selected, int minutes)
    {
        return
            db.DeviceLogs
                .Where(item => item.UserId == selected.UserId)
                .Where(item => (item.LogDate - selected.LogDate).Minutes > 5);
    }
