    public static IList<ClientEntity> FilterNoNeedSendBackToClients(IList<ClientEntity> src)
    {
        if (src == null)
            return null;
        return (from info in src.AsEnumerable<ClientEntity>()
                where !(!String.IsNullOrWhiteSpace(info.ProductNumber) &&
                        info.CancelledByReliantSyncAB01 == (bool?)true)
                where !(String.IsNullOrWhitespace(info.PartnerContract) &&
                        String.IsNullOrWhiteSpace(info.ProductNumber))
                select info).ToList();
    }
