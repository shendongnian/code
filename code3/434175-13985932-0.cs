    Term term = terms.term
    while (null != term) {
        If (term.Field.Equals("category")) {
            // do something with this term
        }
        term = null;
        if (terms.Next())
            term = terms.Term;
    }
