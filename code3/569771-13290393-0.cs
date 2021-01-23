    public IEnumerable<OutputRow> GetOutputRows(InputRow input)
    {
        if ( ** some condition on input.D ** )
            yield return new OutputRow(inputRow, *delegateToProcessor*);
        if ( ** some condition on input.E ** )
            yield return new OutputRow(inputRow, *delegateToProcessor*);
        if ( ** some condition on input.F ** )
            yield return new OutputRow(inputRow, *delegateToProcessor*);
    }
