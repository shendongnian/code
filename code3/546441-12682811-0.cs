    public class IdentifierList : List<Identifier>
    {
        public void Add(Identifier item)
        {
            this.RemoveAll(x => x.Name == item.Name);
            base.Add(item);
        }
    }
    Identifier idn1 = new Identifier { Name = "X" };
    Identifier idn2 = new Identifier { Name = "Y" };
    Identifier idn3 = new Identifier { Name = "Z" };
    Identifier idn4 = new Identifier { Name = "X" };
    Identifier idn5 = new Identifier { Name = "P" };
    Identifier idn6 = new Identifier { Name = "X" };
    
    IdentifierList list = new IdentifierList ();
    list.Add(idn1);
    list.Add(idn2);
    list.Add(idn3);
    list.Add(idn4);
    list.Add(idn5);
    list.Add(idn6);
