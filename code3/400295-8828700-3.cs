        public static string GetDescription(this object enumeration)
        {
            //Again, not going to do your condition/error checking here.
            //Normally I would have made this extension method for the Enum type
            but you won't know the type at compile time when building the list of descriptions but ..
            // you will know its an object so that is how I cheated around it.
            var desc = enumeration.GetType().GetMember(enumeration.ToString())[0]
                .GetCustomAttributes(typeof(DescriptionAttribute), true) as DescriptionAttribute[];
            if (desc != null && desc.Length > 0)
            {
                return desc[0].Description;
            }
            return enumeration.ToString();
        }
