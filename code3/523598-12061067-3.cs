    public Output Calculate(Input input)
    {
       var validator = _context.Validator;
       if (validator.IsInputValid(input)) {
           // ... snip ...
       }
    }
