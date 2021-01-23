            var products = Products.Where(p1 => 
                    Products.Select(p2 => p2.ZipCode)
                            .Distinct()
                            .Where(p3 => p3 >= zipCode)
                            .Take(4)
                            .Union(
                                Products.Select(p4 => p4.ZipCode)
                                .Distinct()
                                .Where(p5 => p5 < zipCode)
                                .Take(3)
                            ).Contains(p1.ZipCode)
                    );
