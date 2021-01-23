    void Main()
    {
    	 int[] counts = new [] { 2,2 };
    	 Choose(counts, 0, new Stack<string>());
    }
    
    void Choose(int[] AnswerCounts, int start, Stack<string> chosen) {
       for (int a=1; a<= AnswerCounts[start]; a++) {
       		chosen.Push("Answer " + a.ToString());
       		if (start < AnswerCounts.Length-1) {
    			Choose(AnswerCounts, start+1, chosen);				
    		}	
    		else {    		    	
                    Console.WriteLine(string.Join(", ", chosen.ToArray()));			
    		}
    		chosen.Pop();
     	}	
     }
