    public static IEnumerable<T> FunkyIEnumerable<T>(this Func<Tuple<bool, T>> nextOrNot)
        {
	        while(true)
	        {
	           var result = nextOrNot();
               
                if(result.Item1)
                    yield return result.Item2;
                else
                    break;
                
	        }
            yield break;
	
        }
        Func<Tuple<bool, int>> nextNumber = () => 
                Tuple.Create(SomeRemoteService.CanIContinueToSendNumbers(), 1);
        foreach(var justGonnaBeOne in nextNumber.FunkyIEnumerable())
                Console.Writeline(justGonnaBeOne.ToString());
