    public interface ILead
    {
        [XmlRpcMethod("leads")]
        string NewLead(leadsParam leads);
    }
