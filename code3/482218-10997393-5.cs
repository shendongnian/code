    public virtual Int32 CompareTo(Person person2)
    {
        Stack<Person> parents1 = GetParents(this);
        Stack<Person> parents2 = GetParents(person2);
        foreach (Person parent1 in parents1)
        {
            Person parent2 = parents2.Pop();
            // These two persons have the same parent tree:
            // Compare their ids
            if (parent1 == null && parent2 == null)
            {
                return 0;
            }
            // 'this' person's parent tree is contained in person2's:
            // 'this' must be a parent of person2
            else if (parent1 == null)
            {
                return -1;
            }
            // 'this' person's parent tree contains person2's:
            // 'this' must be a child of person2
            else if (parent2 == null)
            {
                return 1;
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
        // We should never get here anymore, but if we do,
        // these are the same Person
        return 0;
    }
    
    public static Stack<Person> GetParents(Person p)
    {
        Stack<Person> parents = new Stack<Person>();
        // Add a null so that we don't have to check
        // if the stack is empty before popping.
        parents.Push(null);
        Person parent = p;
        // Recurse through tree to root
        while (parent != null)
        {
            parents.Push(parent);
            parent = parent.Parent;
        }
        return parents;
    }
