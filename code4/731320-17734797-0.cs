    public class AddOrganizationViewModel
        {
            public Music.Models.Organizations Organizations { get; set; }
            public Music.Models.People People { get; set; }
            public Music.Models.OrganizationOptions OrganizationsOptions { get; set; }
            public Music.Models.EmployeeContacts EmployeeContacts { get; set; }
            public int ID { get; set; }
            public string Name { get; set; }
            public bool HasAdminPermissions{ get; set; }
            public bool HasSomeOtherPermission{ get; set; }
            //etc.. for other checkboxes you might need.
        }
