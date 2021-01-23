    object[] data = args.Trim().Split(',');
    foreach(string s in data){
        if(s == "true"){
            s = 1;
            Convert.ToInt32(s);
        }
        else if(s == "false"){
            s = 0;
            Convert.ToInt32(s);
        }
    }
