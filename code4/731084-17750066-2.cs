    using System.Runtime.Serialization;
    [DataContract]
    public class DogDTO
    {
        #region Static Methods
        public static Dog ToDog(DogDTO dto)
        {
            // if the data transfer object is null
            // we cannot make a Dog from it.
            if (dto == null)
            {
                return null;
            }
            Dog dog = new Dog();
            // We can be sure of what these values are intended to be.
            dog.Name = dto.Name;
            dog.Birthday = dto.Birthday;
            return dog;
        }
        public static DogDTO CreateFrom(Dog dog)
        {
            if (dog == null)
            {
                return null;
            }
            DogDTO dto = new DogDTO();
            dto.Name = dog.Name;
            dto.Birthday = dog.Birthday;
        }
        #endregion
        [DataMember]
        public DateTime Birthday { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
