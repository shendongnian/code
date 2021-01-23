    public interface IPerson<TAddressCol, TOtherCol> 
       where TAddressCol: ICollection<Address>
       where TOtherCol : ICollection<OtherType> 
    {
       string Name { get;set;}
       TAddressCol Addresses { get;}
       TAddressCol OtherTypes [ get; } 
    }
