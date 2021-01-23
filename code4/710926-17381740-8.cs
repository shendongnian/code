    public interface IEntityStateProvider
    {
        void Save(object entity);
    
        void Restore(object entity);
    }
    
    public class EntityStateProvider : IEntityStateProvider
    {
        #region Nested type: EditObjectSavedState
    
        private class SavedState
        {
            #region Constructors
    
            public SavedState(PropertyInfo propertyInfo, object value)
            {
                PropertyInfo = propertyInfo;
                Value = value;
            }
    
            #endregion
    
            #region Properties
    
            public readonly PropertyInfo PropertyInfo;
    
            public readonly object Value;
    
            #endregion
        }
    
        #endregion
    
        #region Fields
    
        private static readonly Dictionary<Type, IList<PropertyInfo>> TypesToProperties =
            new Dictionary<Type, IList<PropertyInfo>>();
    
        private readonly Dictionary<object, List<SavedState>> _savedStates = new Dictionary<object, List<SavedState>>();
    
        #endregion
    
        #region Implementation of IEntityStateProvider
    
        public void Save(object entity)
        {
            var savedStates = new List<SavedState>();
            IList<PropertyInfo> propertyInfos = GetProperties(entity);
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                object oldState = propertyInfo.GetValue(entity, null);
                savedStates.Add(new SavedState(propertyInfo, oldState));
            }
            _savedStates[entity] = savedStates;
        }
    
        public void Restore(object entity)
        {
            List<SavedState> savedStates;
            if (!_savedStates.TryGetValue(entity, out savedStates))
                throw new ArgumentException("Before call the Restore method you should call the Save method.");
            foreach (SavedState savedState in savedStates)
            {
                savedState.PropertyInfo.SetValue(entity, savedState.Value, null);
            }
            _savedStates.Remove(entity);
        }
    
        #endregion
    
        #region Methods
    
        private static IList<PropertyInfo> GetProperties(object entity)
        {
            Type type = entity.GetType();
            IList<PropertyInfo> list;
            if (!TypesToProperties.TryGetValue(type, out list))
            {
                list = type.GetProperties()
                        .Where(info => info.CanRead && info.CanWrite)
                        .ToArray();
                TypesToProperties[type] = list;
            }
            return list;
        }
    
        #endregion
    }
