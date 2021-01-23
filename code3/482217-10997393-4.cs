    public virtual Int32 CompareTo(Person person2)
    {
        Stack<Person> parents1 = GetParents(this);
        Stack<Person> parents2 = GetParents(person2);
        foreach (Person parent1 in parents1)
        {
            Person parent2 = parents2.Pop();
            // We've hit the end of the parent tree.
            // These two persons have the same parent tree:
            // Compare their ids
            if (parent1 == null && parent2 == null)
            {
                return this.id.CompareTo(person2.id); ;
            }
            // 'this' person's parent tree is shorter than person2's
            // Compare 'this' to current parent of person2
            else if (parent1 == null)
            {
                return this.id.CompareTo(parent2.id);
            }
            // this person's parent tree is longer than person2's
            // Compare current parent of 'this' to person2
            else if (parent2 == null)
            {
                return parent1.id.CompareTo(person2.id); ;
            }
            // So far, both parent trees are the same size
            // Compare the ids of each parent.
            // If they are the same, go down another level.
            else
            {
                int comparison = parent1.id.CompareTo(parent2.id);
                if (comparison != 0)
                {
                    return comparison;
                }
            }
        }
        // Should only get here if these are the same persons
        return 0;
    }
        
    public Stack<Person> GetParents(Person p)
    {
        Stack<Person> parents = new Stack<Person>();
        // Add a null so that we don't have to check
        // if the stack is empty before popping.
        parents.Push(null);
        Person parent = p.Parent;
        // Recurse through tree to root
        while (parent != null)
        {
            parents.Push(parent);
            parent = parent.Parent;
        }
        return parents;
    }
