    class ContextSerializer
    {
        public void SaveProduct(Product prod)
        {
            using(IContext context = IoC.GetInstance<IContext>())
            {
               context.Save(prod);
            }
         }
    }
