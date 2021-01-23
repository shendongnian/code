            contactPicker.SelectionMode = Windows.ApplicationModel.Contacts.ContactSelectionMode.Fields;
            contactPicker.DesiredFields.Add(Windows.ApplicationModel.Contacts.KnownContactField.Email);
            ContactInformation contact = await contactPicker.PickSingleContactAsync();
            if (contact != null)
            {
                contactName.Visibility = Visibility.Visible;
                contactName.Text = contact.Name;
                EmailValue.Visibility = Visibility.Visible;
                EmailValue.Text = contact.Emails[0].Value.ToString();
            }
