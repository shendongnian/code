        public List<Difference> GetDifferences(List<Person> oldP, List<Person> newP)
        {
            List<Difference> allDiffs = new List<Difference>();
            foreach (Person oldPerson in oldP)
            {
                foreach (Person newPerson in newP)
                {
                    Difference curDiff = GetDifferencesTwoPersons(oldPerson, newPerson);
                    allDiffs.Add(curDiff);
                }
            }
            return allDiffs;
        }
        private Difference GetDifferencesTwoPersons(Person OldPerson, Person NewPerson)
        {
            MemberInfo[] members = typeof(Person).GetMembers();
            Difference returnDiff = new Difference();
            returnDiff.NewPerson = NewPerson;
            returnDiff.OldPerson = OldPerson;
            returnDiff.ChangedProperties = new List<string>();
            foreach (MemberInfo member in members)
            {
                if (member.MemberType == MemberTypes.Property)
                {
                    if (typeof(Person).GetProperty(member.Name).GetValue(NewPerson, null).ToString() != typeof(Person).GetProperty(member.Name).GetValue(OldPerson, null).ToString())
                    {
                        returnDiff.ChangedProperties.Add(member.Name);
                    }
                }
            }
            return returnDiff;
        }
