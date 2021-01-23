    using System.ComponentModel.DataAnnotations;
    [Required] //tells your XAML that this value is required
    [RegularExpression(@"^[0-9\s]{0,40}$")]// only numbers and between 0 and 40 digits allowed
    public int yourIntValue
    {
        get { return myValue; }
        set { myValue= value; }
    }
