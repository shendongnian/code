    contact_to_delete = context.Contacts.Find(contactID);
    selected_activity = context.Activity.Find(ActivityID);
    context.Entry(selected_activity).Collection("Activity").Load();
    selected_activity.Contacts.Remove(contact_to_delete);
    db.SaveChanges(); 
