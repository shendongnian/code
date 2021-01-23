    public class Data { 
       public int Occurrences;
       public decimal Time;
 
       public Data(int occurrences, decimal time) {
         this.Occurrences=occurrences;
         this.Time=time;
       }
    }
    var regex=new Regex(@"^(?<item>.*), (?<hours>\d{2}):(?<minutes>\d{2}):(?<seconds>\d{2})$");
    var dict = new Dictionary<string,Data>();
    
    foreach (var entry in array) {
    	if (regex.IsMatch(entry)) {
    	  var match=regex.Match(entry);
    	  var item=match.Groups["item"].Value;
    	  var time=decimal.Parse(match.Groups["hours"].Value)*60 + 
                                            decimal.Parse(match.Groups["minutes"].Value) +
                                            decimal.Parse(match.Groups["seconds"].Value)/60;
          if (dict.ContainsKey(item)) {
    	  	dict[item].Occurrences++;
                    dict[item].Time+=time);
    	  } else {
    	    dict[item]=new Data(1,time);
    	  }
    	}
    }
    
    StringBuilder sb=new StringBuilder();
    foreach (var key in dict.Keys) {
    	sb.AppendFormat("Item: {0}, # of occurences: {1}, Average Time: {2:0.00}\r\n", key, dict[key].Occurrences, dict[key].Time / dict[key].Occurrences);
    }
    var resultString=sb.ToString();
