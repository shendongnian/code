    //Get the OWA Id
        public String GetOutlookOwaId(EmailMessage message, ExchangeService ser)
        {
            AlternateId ewsId = new AlternateId(IdFormat.EwsId, message.Id.ToString(), "person@example.com");
            AlternateIdBase owaId = ser.ConvertId(ewsId, IdFormat.OwaId);
            return ((AlternateId)owaId).UniqueId;
        }  
         
