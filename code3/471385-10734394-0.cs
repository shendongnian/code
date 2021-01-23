            AcademicProgramOfStudyByNameQueryResponse_InClient client = 
                new AcademicProgramOfStudyByNameQueryResponse_InClient(); 
         
            client.ClientCredentials.UserName.UserName = "XX";
            client.ClientCredentials.UserName.Password = "YY";
            AcademicProgramOfStudyByNameQueryMessage_sync input =
                new AcademicProgramOfStudyByNameQueryMessage_sync();
            input.AcademicProgramOfStudySelectionByName = new AcademicProgramOfStudyByNameQueryMessage_syncAcademicProgramOfStudySelectionByName();
            input.AcademicProgramOfStudySelectionByName.AcademicProgramOfStudyName.languageCode = "DE";
            AcademicProgramOfStudyByNameResponseMessage_sync output = 
                new AcademicProgramOfStudyByNameResponseMessage_sync(); 
            output = client.AcademicProgramOfStudyByNameQueryResponse_In(input);
