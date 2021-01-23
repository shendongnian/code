    using System.Data.Entity.Design.PluralizationServices;
    
    string str = "my {0} has {1} {3}";
    PluralizationService ps = PluralizationService.CreateService(CultureInfo.GetCultureInfo("en-us"));
    str = String.Format(str, "Aunt", value, (value > 1) ? ps.Pluralize("cat") : "cat");
