    public class AddressOverrides : IAutoMappingOverride<Address>
    	{
            public void Override(AutoMapping<Address> mapping)
            {
                mapping.Id(x => x.Id);
                mapping.Map(x => x.PersonId).Column("PersonId");
            }
    	}
