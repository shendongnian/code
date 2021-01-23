    class TestCase
    {
      [StringLength(8, ErrorMessage = "The TestString value cannot exceed 8 characters.")]
      [Required(ErrorMessage="Value Required")]
      property string TestString;
    
      [IntegerValidator(MaxValue = 99999)]
      property int TestInt;
    }
