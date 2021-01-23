    character c = new character();
    c.Name = "Goofy";
    c.Owner = "Me";
    c.Str = new Stat(7);
    MessageBox.Show(c.Str.Value); //The Value
    MessageBox.Show(c.Str.Mod);   //The Mod of Strength
