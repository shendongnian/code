    public static class CarModeStatesExtensions
    {
        public static CarModeStateModel GetMetaData(this CarModeStates value)
        {
            var model = new CarModeStateModel
                {
                    Message = value.GetDescriptionFromEnumValue<string>(typeof (CarStatusAttribute)),
                    IsError = value.GetDescriptionFromEnumValue<bool>(typeof(IsErrorAttribute)),
                    IsUsingPetrol = value.GetDescriptionFromEnumValue<bool>(typeof (IsUsingPetrolAttribute))
                };
            return model;
        }
    }
    public class CarModeStateModel
    {
        public string Message { get; set; }
        public bool IsError { get; set; }
        public bool IsUsingPetrol { get; set; }
    }
    public static class EnumExtensions
    {
        public static T GetDescriptionFromEnumValue<T>(this CarModeStates value, Type attributeType)
        {
            var attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(attributeType, false).SingleOrDefault();
            if (attribute == null)
            {
                return default(T);
            }
            return ((IAttribute<T>)attribute).Description;
        }
    }
