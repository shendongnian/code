    public virtual Int32 CompareTo(Person obj)
    {
        // If this is a child of obj, put this after obj
        if (this.Parent != null && this.IsChild(obj))
        {
            return 1;
        }
        // If obj is a child of this, put obj after this
        else if (obj.Parent != null && obj.IsChild(this))
        {
            return -1;
        }
        // Neither of these are in the same tree, but both
        // have at least one level of parents:
        // compare their trees
        else if (this.Parent != null && obj.Parent != null)
        {
            return CompareTrees(this, obj);
        }
        // obj must be a root, so compare it with the root of this
        else if (this.Parent != null) // && obj.Parent == null
        {
            return GetRoot(this).id.CompareTo(obj.id);
        }
        // this must be a root, so compare the root of this with obj
        else if (obj.Parent != null) // && this.Parent == null
        {
            return this.id.CompareTo(GetRoot(obj).id);
        }
        // Both of these are roots, compare the ids
        else
        {
            return this.id.CompareTo(obj.id);
        }
    }
    
    // Walk up the parent tree to see if this is a child
    // of potentialParent
    public bool IsChild(Person potentialParent)
    {
        Person p = this.Parent;
        // Keep going up a level until we hit a root
        // (p.Parent == null)
        while (p != null)
        {
            if (p.id == potentialParent.id)
            {
                return true;
            }
            p = p.Parent;
        }
        return false;
    }
    
    public virtual Int32 CompareTrees(Person person1, Person person2)
    {
        Stack<Person> parents1 = GetParents(person1);
        Stack<Person> parents2 = GetParents(person2);
        foreach(Person parent1 in parents1)
        {
            Person parent2 = parents2.Pop();
            // These two persons have the same parent tree:
            // Compare their ids
            if (parent1 == null && parent2 == null)
            {
                return 0;
            }
            // person1's parent tree is shorter than person2's
            // Compare person1 to this parent of person2
            else if (parent1 == null)
            {
                return person1.id.CompareTo(parent2.id);
            }
            // person2's parent tree is shorter than person1's
            // Compare this parent of person1 to person2
            else if (parent2 == null)
            {
                return 1;
            }
            // So far, both parent trees are the same size
            // Check the ids of each parent.
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
    // Go up the parent tree until we get to
    // the root parent
    public Person GetRoot(Person p)
    {
        Person parent = p;
        while (parent.id != parent.parentid)
        {
            parent = parent.Parent;
        }
        return parent;
    }
    
    // Go up the parent tree and put each
    // parent into a stack so that we can
    // process them in LIFO order
    // (top parent first)
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
