    public class UserMinistryRef_SelectByUserID
    {
     public int UserRecordId { get; set; }
     public int MinistryId { get; set; }
     public bool Minadmin { get; set; }
     public bool Updater { get; set; }
     public bool Viewer { get; set; }
     public string mname { get; set; }
     public int AccessRights { get; set; } //0 = viewer, 1 = updater, 2 = minadmin
    }
