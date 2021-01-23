    public void addToDict(string ?myObj, Dictionary<,> myDict) {
            if (myObj != null)
                  myDict.Add("...", myObj);
    }
    
    addToDict(myObject.whatever, myDict);
    addToDict(myObject.somethignElse, myDict);
