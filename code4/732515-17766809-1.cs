    public class Objekt_ByCodeAndChildren : AbstractIndexCreationTask<Objekt>
    {
        public Objekt_ByCodeAndChildren()
        {
            Map = objekts => from objekt in objekts
                             from child in objekt.Children
                                 select new
                                 {
                                     objekt.Code,
                                     Children_Role = child.Role,
                                     Children_Place = child.Place
                                 };
        }
    }
