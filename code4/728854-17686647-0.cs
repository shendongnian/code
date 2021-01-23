    using System.Diagnostics.Contracts;
    [ContractClass(typeof(IContactContract))]
    interface IContact
    {
        IAddress address { get; set; }
    }
    
    [ContractClassFor(typeof(IContact))]
    internal abstract class IContactContract: IContact
    {
        IAddress address
        {
            get
            {
                Contract.Ensures(Contract.Result<IAddress>() != null);
                return default(IAddress); // dummy return
            }
        }
    }
    
    [ContractClass(typeof(IAddressContract))]
    interface IAddress
    {
        string city { get; set; }
    }
    
    [ContractClassFor(typeof(IAddress))]
    internal abstract class IAddressContract: IAddress
    {
        string city
        {
            get
            {
                Contract.Ensures(Contract.Result<string>() != null);
                return default(string); // dummy return
            }
        }
    }
    
    class Person
    {
        [ContractInvariantMethod]
        protected void ObjectInvariant()
        {
            Contract.Invariant(contact != null);
        }
        public IContact contact { get; set; }
    }
    
    class test
    {
        private test()
        {
            var person = new Person();
            Contract.Assert(person != null);
            if (person.contact.address.city != null)
            {
                // If you get here, person cannot be null, person.contact cannot be null
                // person.contact.address cannot be null and person.contact.address.city     cannot be null. 
            }
        }
    }
