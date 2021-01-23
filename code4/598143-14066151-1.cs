    public static void ParseBinding(Binding binding)
    {
        var errorProvider = new ErrorProvider();
        binding.Parse += (sender, e) => 
            {
               try
               {
                    // some validation form e.Value
                    // throws exception if not valid
               }
               catch (Exception ex)
               {
                   errorProvider.SetError(binding.Control, ex.Message);
               }
            };
    }
