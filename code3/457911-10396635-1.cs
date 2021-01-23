    public class AddressOverrides : IAutoMappingOverride<Address>
    	{
            public void Override(AutoMapping<Address> mapping)
            {
                mapping.Id(x => x.Id);
                mapping.HasOne(x => x.PersonId).Class(typeof(Person)).PropertyRef("Id");
            }
    	}
