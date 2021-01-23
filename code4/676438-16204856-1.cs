       public List<Clue> NewOrderList(List<Clue> clues)
       {
            List<Clue> newstringOrder = CreateDeepCopy(clues);
		
            // Add code to modify list
			
            return newstringOrder;
       }
		  
    
    public List<Clue> CreateDeepCopy(List<Clue> c)
    {
         //Serialization    
         if(c == null)
                return null;
         BinaryFormatter bf = new BinaryFormatter();
         MemoryStream ms = new MemoryStream();
         bf.Serialize(ms, c);
        
         //Deserialization              
         ms.Position = 0;        
         List<Clue> list = (List<Clue>)bf.Deserialize(ms);       
		
         return list;	 
		 
    }
