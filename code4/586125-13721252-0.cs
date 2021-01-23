    IQueryable<Foo> query = ... // or possibly IEnumerable<Foo>
    if(!string.IsNullOrEmpty(txtMunicipality.text)) {
        query = query.Where(x => x.municipality == txtMunicipality.text);
    }
    if(chkboxIsFinished) {
        query = query.Where(x.isfinished);
    }
