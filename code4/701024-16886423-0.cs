    public DescriptionAttribute GetDescription(ContractorType contractorType)
    {
         MemberInfo memberInfo = typeof(ContractorType).GetMember(contractorType.ToString())
                                              .FirstOrDefault();
         if (memberInfo != null)
        {
             DescriptionAttribute attribute = (DescriptionAttribute) 
                     memberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false)
                               .FirstOrDefault();
             return attribute;
        }
        //return null;
        //or
        throw new NotImplementedException("There is no description for this enum");
    }
