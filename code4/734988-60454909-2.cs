        public void MethodToGetInstances()
        {
               IEnumerable<AbstractDto> dtos = typeof(AbstractDto)
                   .Assembly.GetTypes()
                   .Where(t => t.IsSubclassOf(typeof(AbstractDto)) && !t.IsAbstract)
                   .Select(t => (AbstractDto)Activator.CreateInstance(t))
                   .OrderBy(x => ((EnumDtoAttribute)x.GetType().GetCustomAttributes(typeof(EnumDtoAttribute), false).FirstOrDefault()).Enum);
         
               //If you have parameters on you Dto's, you might pass them to CreateInstance(t, params)
        }
