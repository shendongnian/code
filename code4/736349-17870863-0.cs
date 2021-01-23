    public class NameList : ObservableCollection<PersonName>
    {
         public NameList() : base()
            {
                Add(new PersonName("Willa", "Cather"));
                Add(new PersonName("Isak", "Dinesen"));
                Add(new PersonName("Victor", "Hugo"));
                Add(new PersonName("Jules", "Verne"));
            }
    ...
