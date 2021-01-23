    [ServiceContract]
        public interface IContact
        {
            [OperationContract]
            [WebInvoke(Method="GET", UriTemplate = "GetContact/{idContact}", ResponseFormat=WebMessageFormat.Json)]
            Contact GetContact(string idContact);
            [OperationContract]
            [WebInvoke(Method = "POST", UriTemplate = "AddContact", RequestFormat = WebMessageFormat.Json)]
            string AddContact(Contact contact);
            [OperationContract]
            [WebInvoke(Method = "POST", UriTemplate = "EditContact", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
            string EditContact(string idContact, Contact Contact);
            [OperationContract]
            [WebInvoke(Method = "POST", UriTemplate = "DeleteContact", RequestFormat = WebMessageFormat.Json)]
            string DeleteContact(string idContact);
            [OperationContract]
            [WebInvoke(Method = "GET", UriTemplate = "GetAllContacts/{start}/{end}", RequestFormat = WebMessageFormat.Json)]
            List<Contact> GetAllContacts(string start, string end);        
        }
