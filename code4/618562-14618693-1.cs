    //when you know the parameter values to expect
    mockEmailRequest.Verify(r=>r.EmailReceived(expectedEmail, expectedId));
    
    //when you just want to verify some detail about the values
    mockEmailRequest.Verify(r=>r.EmailReceived(It.Is<EmailResponse>(r=>r.Subject == "Something"), It.Is<int>(i=>i > 17)));
    
    //when you don't care about the values
    mockEmailRequest.Verify(r=>r.EmailReceived(It.IsAny<EmailResponse>(), It.IsAny<int>()));
