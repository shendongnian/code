    private static Dictionary<Binding, ErrorProvider> dict = 
        new  Dictionary<Binding, ErrorProvider>();
    public static void ParseBinding(Binding binding)
    {
         var errorProvider = new ErrorProvider();
         dict.Add(binding, errorProvider);
         binding.Parse += new ConvertEventHandler(binding_Parse);
    }
    static void binding_Parse(object sender, ConvertEventArgs e)
    {
         var binding = sender as Binding;
         var errorProvider = dict[binding];
         try
         {
              // some validation form e.Value
              // throws exception if not valid
         }
         catch (Exception ex)
         {
             errorProvider.SetError(binding.Control, ex.Message);
         }
    }
