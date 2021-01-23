    Array.Sort(properties, (pi1, pi2) =>
        {
            if (pi1.DeclaringType.IsSubclassOf(pi2.DeclaringType))
               return 1;
            else if  (pi2.DeclaringType.IsSubclassOf(pi1.DeclaringType))
                return -1;
            else
                return 0;
        });
