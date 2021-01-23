    public static ListViewItem[] DisplayAllAnimals()
    {
        var animals = new List<ListViewItem>();
    
        //Show animals on ListView by proper column
        foreach (var animal in AnimalList)
        {
            ListViewItem item = new ListViewItem(animal.Id); // generated ID
            item.SubItems.Add(animal.AnimalSort); // AnimalSort
            item.SubItems.Add(animal.Name); //Name
            item.SubItems.Add(animal.Age); //Age
            item.SubItems.Add(animal.Gender.ToString()); // Animal gender
    
            animals.Add(item);
        }
    
        return animals.ToArray();
    }
    
   
    lsbOverview.Items.AddRange(AnimalManager.DisplayAllAnimals());
