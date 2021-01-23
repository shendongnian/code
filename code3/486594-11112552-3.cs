        public ActionResult ExampleCreateView()
        {
            SomeExampleModel model = new SomeExampleModel();
            Contact contactEmail = new Contact();
            contactEmail.Type = ContactType.email;
            Contact contactFax = new Contact();
            contactFax.Type = ContactType.fax;
            Contact contactPhone = new Contact();
            contactPhone.Type = ContactType.Phone;
            Contact contactMobile = new Contact();
            contactMobile.Type = ContactType.mobile;
            List<Contact> contacts = new List<Contact>();
            contacts.Add(contactEmail);
            contacts.Add(contactFax);
            contacts.Add(contactPhone);
            contacts.Add(contactMobile);
            model.Contacts = contacts;
            return View(model);
        }
        [HttpPost]
        public ActionResult ExampleCreateView(SomeExampleModel model)
        {
            //Your operations
            return View(model);
        }
