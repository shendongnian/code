            using (mock.Ordered())
            {
                Expect.Call(productRepository
                    .GetAllProducts())
                    .IgnoreArguments()
                    .Return(new ArrayList());
                Expect.Call(() => productRepository.SaveProduct(product));
            }
