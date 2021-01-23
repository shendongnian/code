    public class Whatever {
       private IMappingService<UserPersonDetails, UserPersonalDetailsDTO> mapper;
       private PersonData personData;
       public Whatever(IMappingService<UserPersonDetails, UserPersonalDetailsDTO> mapper, 
                       PersonData personData) {}
       public UserPersonalDetailsDTO GetUserPersonalDetails(int personId) {
           var userPersonalDetails = personData.GetUserPersonalDetails(personId);
           var userPersonalDetailsDTO = mapper.Map(userPersonalDetails);
           return userPersonalDetailsDTO;
       }
    }
