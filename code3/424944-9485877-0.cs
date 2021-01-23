    if (!(
        Utility.testStringHasValue(txEmail.Text) &&
        Utility.testStringHasValue(txFirstName.Text) &&
        Utility.testStringHasValue(txLastName.Text) &&
        Utility.testStringHasValue(txUserEmployer.Text) &&
        Utility.testStringHasValue(txUserPassword.Text) &&
        Utility.testStringHasValue(txUserPassword2.Text)))
    {
        throw new Exception("Something is false");
    }
