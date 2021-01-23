            using (mock.Ordered())
            {
                Expect.Call(productRepository.GetAllProducts()).Return(new ArrayList());
                Expect.Call(() => productRepository.SaveProduct(product));
            }
            mock.ReplayAll();
            
            using (mock.Playback())
            {
                service.GetAllProducts();
                service.SaveProduct(product);
            }
