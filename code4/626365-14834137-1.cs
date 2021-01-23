                var productResults = ctx.Products.Where(q => q.ProductId == productId && q.Model == productModel).ToList()
                    .Select<Product, ProductDTO>(m =>
                    {
                        Models.ProductDTO dto= new Models.ProductDTO();
                        dto.Id = m.ProductId;
                        dto.Name = m.Name.ToString();
                        dto.Year = m.Year.ToString("MMM ddd d HH:mm yyyy");
                        dto.Model = m.Model;
                        dto.Description = m.Description.ToString();
                        return dto;
                    }).Distinct().ToList().AsParallel();
