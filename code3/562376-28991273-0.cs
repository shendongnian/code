    using AppResources;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;
    using System.Resources;
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            var displayAttrib = enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>();
            var name = displayAttrib.Name;
            var resource = displayAttrib.ResourceType;
            return String.IsNullOrEmpty(name) ? enumValue.ToString()
                : resource == null ?  name
                : new ResourceManager(resource).GetString(name);
        }
    }
