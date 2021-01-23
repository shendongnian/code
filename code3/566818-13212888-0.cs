    var temp=new List<string>(10000);
    var uniqueHash=new HashSet<int>();
    int lineCount=0;
    int uniqueLineCount=0;
    	
    using(var fs=new FileStream(@"C:\windows\panther\setupact.log",FileMode.Open,FileAccess.Read))
    	using(var sr=new StreamReader(fs,true)){
    		while(!sr.EndOfStream){
    		lineCount++;
    		var line=sr.ReadLine();
    		var key=line.GetHashCode();
    			if(!uniqueHash.Contains(key) ){
    				uniqueHash.Add(key);
    				temp.Add(line);
    				uniqueLineCount++;
    					if(temp.Count()>10000){
    						File.AppendAllLines(@"c:\temp\output.txt",temp);
    						temp.Clear();
    					}
    			}
    		}
    	}
    Console.WriteLine("Total Lines:"+lineCount.ToString());
    Console.WriteLine("Lines Removed:"+ (lineCount-uniqueLineCount).ToString());
