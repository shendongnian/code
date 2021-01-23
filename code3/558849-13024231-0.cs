    // inherit
    class AdministrativeDocument : Document { }
    // base class mapping
    class DocumentMap : ClassMap<Document>
    {
        public DocumentMap()
        {
            Id(x => x.Id, "Id")...;
        }
    }
    
    // subclass mapping, same for all three subtables
    class AdministrativeDocumentMap : SubclassMap<AdministrativeDocument>
    {
        public AdministrativeDocumentMap()
        {
            KeyColumn("Id");
        }
    }
