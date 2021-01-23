        for (int i = 0; i < myList.Count; i++)
        {
           var copy = new Double[myList[i].Length];
           Array.Copy(myList[i], copy, myList[i].Length);
           tempList.Add(copy);
        }
