    int i = 8; // your number
    StringBuilder sb = new StringBuilder();
    while(i != 0){
        if(i & 1 != 0){ sb.Insert(0, "1"); }
        else { sb.Insert(0, "0"); }
        i = i >> 1;
    }
    string binary = sb.ToString();
