    public string stVar; // It will not give error.. because it is not in any fuction but 
                         // it is in the scope of class. In this way no need to return
    public void tostringmeth(string concat)
    {
      // string concat;
        string markstring;
        string matricstring;
        markstring = "";
        matricstring = "";
        Mark.ToString(markstring);
        Matric.ToString(matricstring);
       stVar= FirstName + " " + SecondName + " " + DoB+ " " + Course+ " " + markstring + " " + matricstring ;
    }
