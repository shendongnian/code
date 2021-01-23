    Expression<Func<MyObject, bool>> predicate = x => true;
    if(txtMunicipality.text.length > 0){
       predicate = predicate.And(x => x.municipality  == txtMunicipality.text);
    }
    if(chkboxIsFinished){
       predicate = predicate.And(x => x.isfinished == true);
    }
