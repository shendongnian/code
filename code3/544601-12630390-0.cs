    string _exists  = "Adults,Men,Women,Boys";
    string  _check = "Men,Women,Boys,Adults,fail";
    
    
    List<string> exists = new List<string>(_exists.Split(new char[] { ',' }));
    List<string> check = new List<string>(_check.Split(new char[] { ',' }));
    
    foreach(string toCheck in check){
    if(exists.Contains(toCheck)){
      //do things
    }
    }
