    public void Update(Typology typology, string nameOriginalValue)              
      {                                                                             
          if (typology.Name == nameOriginalValue)                                   
          {                                                                         
              _typologyRepository.Update(typology);                                 
              _typologyRepository.Save();                                           
          }                                                                         
          else if (IsUniqueName(typology.Name))                                     
          {                                                                         
              _typologyRepository.Update(typology);                                 
              _typologyRepository.Save();                                           
          }                                                                         
          else                                                                      
              _validatonDictionary.AddError("Name", errorMessageNameUnique);        
          }                                                                         
      }                                                                             
 
