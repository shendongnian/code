    public class LooksLikeAnIServiceRecherche : IServiceRecherche<IUnite, ICritereRechercheUnite>
    {
        private readonly dynamic _duck;
        public LooksLikeAnIServiceRecherche (dynamic duck)
        {
            this._duck = duck;
        }
        public IList<IUnite> Rechercher(ICritereRechercheUnite critere)
        {
            return this._duck.Rechercher(critere);
        }
    }
