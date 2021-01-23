    foreach(Control c in this.Controls) // this is the form object on which Controls is the ControlCollection
    {
       if(c is Button)
       {
           KnownColor[] names = (KnownColor[]) Enum.GetValues(typeof(KnownColor));
           KnownColor color= names[randomGen.Next(names.Length)];
           Color color = Color.FromKnownColor(randomColorName);
           c.BackColor = color;
       }
    }
