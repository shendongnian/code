    public class PokemonReverseNameComparer : IComparer<Pokemon>
    {
        public int Compare(Pokemon x, Pokemon y)
        {
            return StringComparer.OrdinalIgnoreCase.Compare(y.Name, x.Name);
        }
    }
