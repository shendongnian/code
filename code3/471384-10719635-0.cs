        AcademicProgramOfStudyByNameQueryResponse_InClient client = 
            new AcademicProgramOfStudyByNameQueryResponse_InClient(); 
        client.ClientCredentials.UserName.UserName = "XX";
        client.ClientCredentials.UserName.Password = "YY";
        AcademicProgramOfStudyByNameQueryMessage_sync input =
            new AcademicProgramOfStudyByNameQueryMessage_sync();
        input.AcademicProgramOfStudySelectionByName = new AcademicProgramOfStudyByNameQueryMessage_syncAcademicProgramOfStudySelectionByName();
        // this is the member that currently is still NULL and has to be created:
        input.AcademicProgramOfStudySelectionByName.AcademicProgramOfStudyName = new <insert whatever class is needed here>
        
        // now this should work without throwing an exception
       input.AcademicProgramOfStudySelectionByName.AcademicProgramOfStudyName.languageCode = "DE";
        AcademicProgramOfStudyByNameResponseMessage_sync output = 
            new AcademicProgramOfStudyByNameResponseMessage_sync(); 
        output = client.AcademicProgramOfStudyByNameQueryResponse_In(input);
