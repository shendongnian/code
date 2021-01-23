        // declared in AnimalManager class
        private static List<Animal> AnimalList { get; set; }
        
         public static IEnumerable<ListViewItem> DisplayAllAnimals()
        {
            //Show animals on ListView by proper column
            foreach (var animal in AnimalList)
            {
                ListViewItem item = new ListViewItem(animal.Id); // generated ID
                item.SubItems.Add(animal.AnimalSort); // AnimalSort
                item.SubItems.Add(animal.Name); //Name
                item.SubItems.Add(animal.Age); //Age
                item.SubItems.Add(animal.Gender.ToString()); // Animal gender
                yield return item;
            }
        }
        // Mainform UI class where its used
        lsbOverview.Items.AddRange(AnimalManager.DisplayAllAnimals());
