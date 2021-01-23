    private bool IsSoleInProduction(long? shoeLastID)
    {
        // The main change: A default value, assuming "no":
        var isSoleInProduction = false; 
        if (shoeLastID == null)
        {
            MessageBox.Show(Resources.ERROR_SAVE, 
                            "Error", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
            isSoleInProduction = false;
        }
        ISoleService soleService = 
            UnityDependencyResolver.Instance.GetService<ISoleService>();
        List<Sole> entity = 
            soleService.All().Where(s => s.ShoeLastID == shoeLastID).ToList();
    
        if (entity.Count() != 0)
        {
            foreach (var items in entity)
            {
                if (items.Status == 20)
                {
                    isSoleInProduction = true;
                }
                else
                {
                    isSoleInProduction = false;
                }
            }
        }
        else
        {
            isSoleInProduction = false;
        }    
        return isSoleInProduction;
    }
