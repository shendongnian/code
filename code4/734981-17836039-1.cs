    public static class DtoFactory
    {
        public static AbstractDto Create(DtoSelection dtoSelection)
        {
            var type = Type.GetType(typeof(AbstractDto).Namespace + "." + dtoSelection.ToString(), throwOnError: false);
            if (type == null)
            {
                throw new InvalidOperationException(dtoSelection.ToString() + " is not a known dto type");
            }
            if (!typeof(AbstractDto).IsAssignableFrom(type))
            {
                throw new InvalidOperationException(type.Name + " does not inherit from AbstractDto");
            }
            return (AbstractDto)Activator.CreateInstance(type);
        }
    }
