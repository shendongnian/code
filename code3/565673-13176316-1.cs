    [SecurityPermission(SecurityAction.InheritanceDemand, Flags=SecurityPermissionFlag.Infrastructure)]
    public override string ToString()
    {
        if (this.m_Syntax == null)
        {
            if (this.m_iriParsing && this.InFact(Flags.HasUnicode))
            {
                return this.m_String;
            }
            return this.OriginalString;
        }
        this.EnsureUriInfo();
        if (this.m_Info.String == null)
        {
            if (this.Syntax.IsSimple)
            {
                this.m_Info.String = this.GetComponentsHelper(UriComponents.AbsoluteUri, (UriFormat) 0x7fff);
            }
            else
            {
                this.m_Info.String = this.GetParts(UriComponents.AbsoluteUri, UriFormat.SafeUnescaped);
            }
        }
        return this.m_Info.String;
    }
