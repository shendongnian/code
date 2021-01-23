     public void separate(string yourString){
    //s= yourString;
    string s = "10.2";
    string part1;
    string part2;
    	//
    	// Split string on dot.
    	// ... This will separate into 2 parts if exist .
    	//
    	string[] words = s.Split('.');
    
    if(words[0].Length == 2){
    	part1 = words[0];
            }else{
                if (words[0].Length == 1){
                    part1 = "0" + words[0];
                }else{ part1 = "00";}
            }
    
    
    if(words[1].Length == 2){
    	part2 = words[1];
            }else{
                if (words[1].Length == 1){
                part1 = "0" + words[0];
                }else{ part1 = "00";}
           }
    }
 
    public string rebuild(string part1 , string part2)
     {
         string final = part1.Replace("0", "") +"."+ part2.Replace("0", "");
    
         return final;
     }
