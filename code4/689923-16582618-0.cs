    public class GenericRecommendationForm 
    {
        // ...
    
        public virtual GenericRecommendationForm Clone()
        {
            return new GenericRecommendationForm(this);
        }
    }
    
    public class TypeARecommendationForm
    {
        // ...
    
        public override GenericRecommendationForm Clone()
        {
            return new TypeARecommendationForm(this);
        }
    }
    
    public class TypeBRecommendationForm
    {
        // ...
    
        public override GenericRecommendationForm Clone()
        {
            return new TypeBRecommendationForm(this);
        }
    }
