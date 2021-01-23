            mapper[(int) ReviewStepType.StandardLetter].Invoke();
            caseDecisionService.AssertWasCalled(c => c.ProcessSendStandardLetter(aCase),
                                                options => options.IgnoreArguments());
            caseDecisionService.AssertWasNotCalled(c =>  
                                                   c.ProcessSendBespokeLetter(aCase),
                                                   options => options.IgnoreArguments());
            caseDecisionService.AssertWasNotCalled(c => 
                                                   c.ProcessContinueAsCase(aCase),
                                                   options => options.IgnoreArguments());
