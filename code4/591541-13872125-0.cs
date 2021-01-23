		public ActionResult Details() {
			UserDetailsModel model = new UserDetailsModel();
			foreach( var doc in _attachmentRepository.GetPersonAttachments( Globals.UserID ) ) {
				DocumentItemModel item = new DocumentItemModel();
				item.AttachmentID = doc.ID;
				item.DocumentIcon = AttachmentHelper.GetIconFromFileName( doc.StoragePath );
				item.DocumentName = doc.DocumentName;
				item.UploadedBy = string.Format( "{0} {1}", doc.Forename, doc.Surname );
				item.Version = doc.VersionID;
				model.Documents.Add( item );
			}
			var person = _peopleRepository.GetPerson();
			var address = _peopleRepository.GetAddress();
			MapPersonToModel( model, person );
			MapAddressToModel( model, address );
			model.DocumentModel.EntityType = 1;
			model.DocumentModel.ID = Globals.UserID;
			model.DocumentModel.NewFile = true;
			var countries = _countryRepository.GetCountries();
			model.AddressModel.Countries = countries.ToSelectListItem( 1, c => c.ID, c => c.CountryName, c => c.CountryName, c => c.ID.ToString() );
			return View( model );
		}
		public void MapAddressToModel( UserDetailsModel model, Address address ) {
			model.AddressModel.AddressLine1 = address.AddressLine1;
			model.AddressModel.AddressLine2 = address.AddressLine2;
			model.AddressModel.City = address.City;
			model.AddressModel.County = address.County;
			model.AddressModel.Postcode = address.Postcode;
			model.AddressModel.Telephone = address.Telephone;
		}
		public void MapPersonToModel( UserDetailsModel model, Person person ) {
			model.PersonModel.DateOfBirth = person.DateOfBirth;
			model.PersonModel.Forename = person.Forename;
			model.PersonModel.Surname = person.Surname;
			model.PersonModel.Title = person.Title;
		}
