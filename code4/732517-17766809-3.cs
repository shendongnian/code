    // Index key representation of an Objekt
    public class ObjektKey
    {
        public string Code { get; set; }
        public string Role { get; set; }
        public string Place { get; set; }
    }
    // Query for ObjektKey instances, before finally transforming them to Objekt
    session.Query<ObjektKey, Objekt_ByCodeAndChildren>()
                .Where(o => o.Code == "1" && o.Role == "A" && o.Place == "Here")
                .OfType<Objekt>()
        
