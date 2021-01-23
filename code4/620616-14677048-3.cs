            using (mock.Record())
            using (mock.Ordered())
            {
                Expect.Call(productRepository.GetAllProducts()).Return(new ArrayList());
                Expect.Call(() => productRepository.SaveProduct(product));
            }
