    var _requiresQA = Membership.Provider.GetType().GetField("_RequiresQuestionAndAnswer",
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
        //change the value in the private field
        _requiresQA.SetValue(Membership.Provider, false);
        //do the reset
        tempPassword = user.ResetPassword();
        //set it's original value
        _requiresQA.SetValue(Membership.Provider, true);
