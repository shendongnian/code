    List<string> myList1 = new List<string>(); //Initializes a new List of string of name myList1
    private void ListItems()
    {
        AddItem("myFirstItem"); //Calls AddItem to add an item to the list of name myFirstItem
        AddItem("mySecondItem"); //Calls AddItem to add an item to the list of name mySecondItem
        AddItem("myThirdItem"); //Calls AddItem to add an item to the list of name myThirdItem
        string[] myArray1 = GetAllItemsAsArray(myList1); //Calls GetAllItemsAsArray to return a string array from myList1
     /* foreach (string x in myArray1) //Get each string in myArray1 as x
        {
            MessageBox.Show(x); //Show x in a MessageBox
        }   */
    }
    private void RemoveItem(string name)
    {
        myList1.RemoveAt(myList1.IndexOf(name)); //Removes an item of name "name" from the list using its index
    }
    private void AddItem(string name)
    {
        myList1.Add(name); //Adds an item of name "name" to the list
    }
    private string[] GetAllItemsAsArray(List<string> list)
    {
        string[] myArray = new string[list.Count]; //Initialize a new string array of name myArray of length myList1.Count
        for (int i = 0; i < list.Count; i++)  //Initialize a new int of name i as 0. Continue only if i is less than myList1.Count. Increment i by 1 every time you continue
        {
            myArray[i] = list[i]; //Set the item index of i where i represents an int of myArray to the corresponding index of int in myList1
        }
        return myArray; //Return myArray
    }
