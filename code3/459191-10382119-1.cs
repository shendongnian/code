    int i = 8; // your number
    int noZeros = 5;
    StringBuilder sb = new StringBuilder();
    while(i != 0 && noZeros > 0){
        if(i & 1 != 0){ sb.Insert(0, "1"); }
        else { sb.Insert(0, "0"); }
        i = i >> 1;
        noZeros --;
    }
    string binary = sb.ToString();
