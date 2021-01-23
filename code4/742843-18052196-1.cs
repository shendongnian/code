         public class MultiDimDictList<K, T>: Dictionary<K, List<T>>  
           {
               public void Add(K key, T addObject)
               {
                   if(!ContainsKey(key)) 
                   {
                   Add(key, new List<T>());
                   base[key].Add(addObject);
                   }else{
                   for(int i=1; i<i+1;i++){
                    if(!ContainsKey(key+"_"+i)){
                        Add(key+"_"+i+, new List<T>());
                        base[key+"_"+i].Add(addObject+"_"+i);       
                        break;
                      }
                    }
                  }  
               }           
           }
