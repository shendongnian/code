     public class FlowViewModel
     {
        private List<Poste> _postesItems = null;
        public List<Poste> PostesItems
        {
           get
           {
              return _postesItems ?? new List<Poste>();
           }
           set
           {
              _postesItems = value ?? new List<Poste>();
           }
        }
     }
