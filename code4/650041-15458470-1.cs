    var assembly = Assembly.LoadFrom("ResourcesLib.DLL");            
    var resourceManager =
    new ResourceManager("ResourcesLib.EnumDescriptions", assembly);                        
                
    var lst = Enum.GetValues(typeof(PersonGender)).Cast<PersonGender>().ToList();
    foreach (var gender in lst)
    {
      Console.WriteLine(gender); // Name
      Console.WriteLine((int)gender); //Int Value
      Console.WriteLine(resourceManager.GetString(gender.ToString()));//localized Resorce
    }          
