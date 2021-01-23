        public ProductProcessorFactory()
        {
        }
        public IBaseProductProcessor<T> Create<T>(T product) where T : Product
        {
            switch (product.ProductType)
            {
                case ProductType.Standard:
                    var spp = new StandardProductProcessor(product as StandardProduct); 
                    return spp as IBaseProductProcessor<T>;//no more nulls!
            }
            return null;
        }
    }
