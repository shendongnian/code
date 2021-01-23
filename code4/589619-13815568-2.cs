            public int Add(FruitTrees NewItem)
            {
                FruitTrees Sample = new FruitTrees();
                Sample = NewItem;
                Sample.Next = First;
                First = Sample;
                //Last = First.Next;
                // Since Add is an  operation that prepends to the list - only update
                // Last for the first time:
                if (Last == null){
                  Last = First;
                }
                return size++;
            }
