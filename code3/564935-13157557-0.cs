    public Part SelectPart(String PartRef)
    {
        return m_supplierParts.Single(p => p.PartNumber.ToString().Equals(
                                       PartRef, StringComparison.OrdinalIgnoreCase));
    }
