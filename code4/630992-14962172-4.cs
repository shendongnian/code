    public class PetPosterGenerator : 
        IPosterGenerator<PetPoster>
    {
        IQueryable<PetPoster> GetPosters()
        {
            return busLogic.GetPetPosters();
        }
        // Explicit interface implementation on non-generic method
        IQueryable IPosterGenerator.GetPosters()
        {
            // Invokes generic version
            return this.GetPosters();
        }
    }
