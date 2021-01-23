    namespace Stackoverflow
    {
        public class ContactBLLService
        {
            private ContactDbService _dbService;
            public ContactBLLService()
            {
                _dbService = new ContactDbService();
            }
    
            public bool CheckValidContact(Guid contactID)
            {
                var contact = _dbService.GetContactByID(contactID);
    
                return contact.Age > 50;
    
            }
        }
    }
