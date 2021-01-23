     TextReader reader = new StreamReader(path);
     IEnumerable<string> data = this.ReadLines(reader);  
     foreach (var s in data){
         // make sure its not null doesn't start with an empty line or something.
         if (s != null && !string.IsNullOrEmpty(s) && !s.StartsWith("  ") && s.Length > 0){
            s = s.ToLower().Trim();
           
            // use regex to find some key in your case the "ID".
            // look into regex and word boundry find only lines with ID
            // double check the below regex below going off memory. \B is for boundry
            var regex = new Regex("\BID\B");
            var isMatch = regex.Match(s.ToLower());
            if(isMatch.Success){ 
               // split the spaces out of the line.
               var arr = s.split(' ');
               var id = arr[1]; // should be second obj in array.
               
            }
            
         }
     }
