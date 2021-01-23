    filtered = dvds.Where(dvd => HasActor(dvd, firstName, lastName));
    ...
    
    bool HasActor(XElement dvd, string firstName, string lastName)
    {
        var actors = dvd.Element("Actors");
        if (actors != null)
        [
            var actor = actor.FirstOrDefault(a => IsActor(a, firstName, lastName));
            return actor != null;
        }
        return false;
    }
    
    bool IsActor(XElement actor, string firstName, string lastName)
    {
        string firstNameAttr = actor.Attribute("FirstName");
        string lastNameAttr = actor.Attribute("LastName");
        return firstNameAttr != null
            && firstNameAttr.Value == firstName
            && lastNameAttr != null
            && lastNameAttr.Value == lastName;
    }
