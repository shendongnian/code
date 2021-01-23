            string ddstart = scheduledDate;
            string ddend = string.Empty;
            string duration = string.Empty;
            ddend = scheduledDate;
            
            string method = "REQUEST";
            string status = "CONFIRMED";
            string UID = Guid.NewGuid().ToString();
            string lastmodified = scheduledDate;
            string created = scheduledDate;
            string dtstamp = scheduledDate;
            string sequence ="0";
            Dictionary<string, string> keycollection = new Dictionary<string, string>{
                            {"[YYYYMMDD]", ddstart},
                            {"[SCHEDULERNAME]", scheduler},
                            {"[SCHEDULEREMAIL]", scheduleremail},   
                            {"[CANDIDATENAME]", applicant},
                            {"[CANDIDATEEMAIL]", applicantemail},
                            {"[INTERVIEWERNAME]", interviewer},
                            {"[INTERVIEWEREMAIL]", intervieweremail},
                            {"[YYYYMMDDTHHmmssZ]",lastmodified},
                            {"[VENUE]", venue},
                            {"[NOTES]",notes},
                            {"[GUID]",UID},
                            {"[subject]","Interview scheduled"},
                            {"[method]",method},
                            {"[status]",status},{"[sequence]",sequence}};
     attachment = StringHelpers.ReplaceStringValue(attachment, keycollection);
            byte[] byteArray = Encoding.UTF8.GetBytes(attachment);          
            MemoryStream MemoryStreamData= new MemoryStream(byteArray);
