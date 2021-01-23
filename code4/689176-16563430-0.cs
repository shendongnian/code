    MWCompetitionContestantsDetails user = new MWCompetitionContestantsDetails(){
            FirstName = firstNameText.Value,
            LastName = lastNameText.Value,
            UserEmailAddress = emailText.Value,
            Address1= address1Text.Value,
            Address2 = address2Text.Value,
            City = cityText.Value,
            Province= provinceText.Value,
            PostalCode = postCodeText.Value,
            Country = countryText.SelectedItem.Text
    };
    user.Save();
