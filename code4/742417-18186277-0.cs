    public override System.Collections.IEnumerable Query(QueryDescription queryDescription, out IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> validationErrors, out int totalCount)
    {
        IEnumerable result = base.Query(queryDescription, out validationErrors, out totalCount);
            
        // now you have collection with all client query operators applied and
        // you can apply post-processing
        if (queryDescription.Method.Name == "GetQry_ClientList")
        {
            result.OfType<qry_ClientList>().ToList().ForEach(c => Descrypt(c));
        }
        return result;
    }
