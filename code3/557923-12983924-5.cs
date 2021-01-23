    public string tostringmeth(string concat)
    {
      // string concat;
        string markstring;
        string matricstring;
        markstring = "";
        matricstring = "";
        Mark.ToString(markstring);
        Matric.ToString(matricstring);
       concat= FirstName + " " + SecondName + " " + DoB+ " " + Course+ " " + markstring + " " + matricstring ;
      return concat;
    }
