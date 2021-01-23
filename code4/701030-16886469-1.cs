    public string ContractorTypeDescription(Enum ContractorType)
    {
        FieldInfo fi = ContractorType.GetType().GetField(ContractorType.ToString());
        var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
        if (attributes.Length > 0)
        {
            return attributes[0].Description;
        }
        else
        {
            return ContractorType.ToString();
        }
    }
