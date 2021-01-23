            using (mock.Ordered())
            {
                Expect.Call(productRepository
                    .GetAllProducts())
                    .IgnoreArguments()
                    .Return(new ArrayList());
                productRepository.SaveProduct(product);
            }
