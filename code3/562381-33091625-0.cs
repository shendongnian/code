    public static class EnumExtensions
        {
            public static DisplayAttributeValues GetDisplayAttributeValues(this Enum enumValue)
            {
                var displayAttribute = enumValue.GetType().GetMember(enumValue.ToString()).First().GetCustomAttribute<DisplayAttribute>();
    
                return new DisplayAttributeValues(enumValue, displayAttribute);
            }
    
            public sealed class DisplayAttributeValues
            {
                private readonly Enum enumValue;
                private readonly DisplayAttribute displayAttribute;
    
                public DisplayAttributeValues(Enum enumValue, DisplayAttribute displayAttribute)
                {
                    this.enumValue = enumValue;
                    this.displayAttribute = displayAttribute;
                }
    
                public bool? AutoGenerateField => this.displayAttribute?.GetAutoGenerateField();
                public bool? AutoGenerateFilter => this.displayAttribute?.GetAutoGenerateFilter();
                public int? Order => this.displayAttribute?.GetOrder();
                public string Description => this.displayAttribute != null ? this.displayAttribute.GetDescription() : string.Empty;
                public string GroupName => this.displayAttribute != null ? this.displayAttribute.GetGroupName() : string.Empty;
                public string Name => this.displayAttribute != null ? this.displayAttribute.GetName() : this.enumValue.ToString();
                public string Prompt => this.displayAttribute != null ? this.displayAttribute.GetPrompt() : string.Empty;
                public string ShortName => this.displayAttribute != null ? this.displayAttribute.GetShortName() : this.enumValue.ToString();
            }
        }
