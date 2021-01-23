    class Surrogate : IDataContractSurrogate {
    
        public Type GetDataContractType(Type type) {
            if (typeof(Animal).IsAssignableFrom(type)) return typeof(int);
            return type;
        }
    
        public object GetObjectToSerialize(object obj, Type targetType) {
            // map any animal to its ID
            if (obj is Animal) return ((Animal)obj).ID;
            return obj;
        }
    
        public object GetDeserializedObject(object obj, Type targetType) {
            // use the static accessor instead of a constructor!
            if (targetType == typeof(Animal)) return Animal.GetAnimalById((int)obj);
        }
    }
