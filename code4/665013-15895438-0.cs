     private bool IsSoleInProduction(long? shoeLastID)
            {
                if (shoeLastID == null)
                {
                    MessageBox.Show(Resources.ERROR_SAVE, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                ISoleService soleService = UnityDependencyResolver.Instance.GetService<ISoleService>();
                List<Sole> entity = soleService.All().Where(s => s.ShoeLastID == shoeLastID).ToList();
    
                if (entity.Count() != 0)
                {
                    foreach (var items in entity)
                    {
                        if (items.Status == 20)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return false;
            }
