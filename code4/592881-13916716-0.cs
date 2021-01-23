    public TermFacetDescriptor<CatalogMapping> FacetBuilder(TermFacetDescriptor<CatalogMapping> termFacet, FacetOptions options)
        {
            termFacet.OnField(options.Field);
            termFacet.Size(options.Size);
            if (options.IncludeAllTerms)
                termFacet.AllTerms();
            return termFacet;
        }
