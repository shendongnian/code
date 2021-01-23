    foreach (Tuple<IItem, FirstObjectTag> taggedItem in myList)
    {
        switch (taggedItem.Item2)
        {
            case U1: /* taggedItem.Item1 is a FirstObject<T, U1> */
            case U2: /* taggedItem.Item1 is a FirstObject<T, U2> */
            case U3: /* taggedItem.Item1 is a FirstObject<T, U3> */
            // ...
        }
    }
