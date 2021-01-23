    //api/Group/
    public List<GroupModel> Get()
    public GroupModel Get(int ID)
    public GroupModel Post(GroupModel model)  //add a group
    public GroupModel Put(GroupModel model)   //update a group (see comments above)
    public void Delete(int ID)
    
    
    //api/GroupContacts/
    public ContactsModel Get()                    //gets complete list
    public void PostContacts(ContactsModel model) //pushes a COMPLETE new state
    public void Delete()                          //delete entire group of contacts
    //api/GroupContact/354/
    public ContactModel Get(int id)             //get contact id #354
    public void PostContact(ContactModel model) //add contact (overwrite if exits)
    public void Delete(int id)                  //delete contact if exists
