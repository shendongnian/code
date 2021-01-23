    private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in Enum.GetValues(typeof(Races)))
            {
                cbRace.Items.Add(item);
            }
        }
        enum Races
        {
            Human = 1,
            Dwarf,
            Elf,
            Orc,
            Goblin,
            Vampire,
            Centaur
        }
