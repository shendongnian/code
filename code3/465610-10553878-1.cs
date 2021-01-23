    private Dictionary<string,string> GetGender(){
        Dictionary<string, string> myDic = new Dictionary<string, string>();
        myDic.Add(System.DBNull.Value.ToString(), "Select");
        myDic.Add("Male", "Male");
        myDic.Add("Female", "Female");
        return myDic;
    }
