    using System.ComponentModel.DataAnnotations.Schema;
    [NotMapped]
    public ICollection<Cards> RemainingCards
    {
        get
        {
            return AllCards.Where(s => s.SomeCiteria == true).ToList();
        }
    }
