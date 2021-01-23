    abstract class Party {
        int Field1 {get;set;}
        int Field2 {get;set;}
        virtual ICollection<PartyType1Party> Parties {get;}
    }
    class Person {
        string Name {get;set;}
        int Age {get;set;}
    }
    class OrganizationParty {
        int Something {get;set;}
        int OtherThing {get;set;}
        virtual ICollection<PartyType2Party> Parties {get;}
    }
    class PartyType1Party : Party {
        Person OrganizerOrSomeRandomPropertyName {get;set;}
    }
    class PartyType2Party : Party {
        OrganizationPart Organization {get;set;}
    }
    class Context : DbContext {
        DbSet<Party> Parties {get;set;}
        DbSet<Person> Persons {get;set;}
        DbSet<OrganizationParty> OrganizationParties {get;set;}
    }
