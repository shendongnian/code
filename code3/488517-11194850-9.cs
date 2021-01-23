    public ActionResult GetContacts()
    {
        List<Contact> list = new List<Contact>();
        Contact contact = new Contact() { ContactId = 0, Name = "Steve", Address = "Some Street", Phone = "1-345-345-3455", Zip = "334566" };
        list.Add(contact);
        contact = new Contact() { ContactId = 1, Name = "Jim", Address = "Another Street", Phone = "1-777-987-3889", Zip = "998754" };
        list.Add(contact);
        return Json(list, JsonRequestBehavior.AllowGet);
    }
