    public MyStatusID StatusEnum {
        get {
            return (MyStatusID)Enum.Parse(typeof(MyStatusID), StatusID)
        }
        private set;
    }
    in .Net 4.0:
    public MyStatusID StatusEnum {
        get {
            MyStatusID value;
            if(!Enum.TryParse(StatusID, out value)
              value = MyStatusID.Default; // default value, instead of Exception throwing
            return value;
        }
        private set;
    }
