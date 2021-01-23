    UserViewModel user = new UserViewModel();
    user.Name = "Me";
    user.Products = new List<ProductViewModel>
                    {
                        new ProductViewModel
                        {
                            Id = 1,
                            Name = "Prod1",
                            Roles = new List<RoleViewModel>
                            {
                                new RoleViewModel
                                {
                                    Id = 1,
                                    Name = "Role1",
                                    IsSelected = false
                                }
                                // add more roles
                            }
                        }
                        // add more products with the same roles as Prod1 has
                     };
