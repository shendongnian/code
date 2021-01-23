    //when you know the parameter values to expect
    mockEmailRequest.Verify(r=>r.EmailRecevied(expectedEmail, expectedId));
    
    //when you just want to verify some detail about the values
    mockEmailRequest.Verify(r=>r.EmailRecevied(It.Is<EmailResponse>(r=>r.Subject == "Something"), It.Is<int>(i=>i > 17)));
    
    //when you don't care about the values
    mockEmailRequest.Verify(r=>r.EmailRecevied(It.IsAny<EmailResponse>(), It.IsAny<int>()));
