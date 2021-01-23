    public bool StringContainsData(string aString, bool answerToDate) {
        return answerToDate && !string.IsNullOrWhiteSpace(aString);
    }
    public bool inputsContainData() {        
        bool validInputs = True;        
        
        validInputs = _helper.StringContainsData(_view.FilePath1, validInputs);        
        validInputs = _helper.StringContainsData(_view.FilePath2, validInputs);        
        
        return validInputs;        
    }        
