    [Validator(typeof(PlaceValidator))]
    class Place
    {
    	public int Id { get; set; }
    	public DateTime DateAdded { get; set; }
    	public string Name { get; set; }
    	public string Url { get; set; }
    }
    
    public class PlaceValidator : AbstractValidator<Place>
    {
    	public PlaceValidator()
    	{
    		RuleFor(x => x.Name).NotEmpty().WithMessage("Place Name is required").Length(0, 100);
    		RuleFor(x => x.Url).Must(BeUniqueUrl).WithMessage("Url already exists");
    	}
    	
    	private bool BeUniqueUrl(string url)
    	{
    		var _db = new DataContext();
    		if (_db.Places.SingleOrDefault(x => x.Url == url) == null) return true;
    		return false;
    	}
    }
