	class MyCoolModelMapping
        : BaseMapping<Model.MyCoolModel>
    {        
        public MyCoolModelMapping() 
        {
            Property(r => r.AttributesData).HasColumnType("xml");
        }
    }
	
