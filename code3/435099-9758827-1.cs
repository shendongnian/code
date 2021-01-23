        public List<Name> GetNames() 
        { 
     
            NamesModel model = new NamesModel(); 
            List<Name> names = model.GetNames(); 
            // ?? serviceName.NameID = modelName.NameID;  
            // ?? serviceName.Name = modelName.Name; 
     
            model.Close(); 
     
            return names; 
        } 
    
