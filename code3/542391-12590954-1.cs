        [XmlIgnore]
        public BitmapImage ContactPicture
        {
            get {
                if (_ContactPicture != null) {
                    return _ContactPicture;
                } else {
                    BitmapImage contactPictureSource = App.ContactPictures.GetContactPicture(Email, DisplayName);
                    if (contactPictureSource != null) {
                        return contactPictureSource;
                    } else {
                        Contacts contacts = new Contacts();
                        contacts.SearchCompleted += new EventHandler<ContactsSearchEventArgs>(contacts_SearchCompleted);
                        contacts.SearchAsync(DisplayName, FilterKind.DisplayName, Email);
                        return new BitmapImage();
                    }
                }
            }
            set {
                _ContactPicture = value;
                //When _ContactPicture is setted, an event is raised by calling to NotifyPropertyChanged()
                NotifyPropertyChanged("ContactPicture");
            }
        }
        void contacts_SearchCompleted(object sender, ContactsSearchEventArgs e) {
            Contact contact = null;
            foreach (var result in e.Results) {
                foreach (ContactEmailAddress contactEmail in result.EmailAddresses) {
                    if (Email.Equals(contactEmail.EmailAddress)) {
                        contact = result;
                        this.ContactPicture = GetSourceImageFromContactPicture(contact.GetPicture());
                        break;
                    }
                }
            }
        }        
    }
