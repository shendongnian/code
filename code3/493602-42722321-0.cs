    using System;
    using System.ComponentModel.DataAnnotations;
        
    namespace YourNameSpaceHere.Support
    {
        [AttributeUsage(AttributeTargets.Class)]
        public class DisplayForClassAttribute : Attribute
        {
            protected readonly DisplayAttribute Attribute;
    
            public DisplayForClassAttribute()
            {
                this.Attribute = new DisplayAttribute();
            }
    
            public string ShortName
            {
                get { return this.Attribute.ShortName; }
                set { this.Attribute.ShortName = value; }
            }
    
            public string Name
            {
                get { return this.Attribute.Name; }
                set { this.Attribute.Name = value; }
            }
    
            public string Description
            {
                get { return this.Attribute.Description; }
                set { this.Attribute.Description = value; }
            }
    
            public string Prompt
            {
                get { return this.Attribute.Prompt; }
                set { this.Attribute.Prompt = value; }
            }
    
            public string GroupName
            {
                get { return this.Attribute.GroupName; }
                set { this.Attribute.GroupName = value; }
            }
    
            public Type ResourceType
            {
                get { return this.Attribute.ResourceType; }
                set { this.Attribute.ResourceType = value; }
            }
    
            public bool AutoGenerateField
            {
                get { return this.Attribute.AutoGenerateField; }
                set { this.Attribute.AutoGenerateField = value; }
            }
    
            public bool AutoGenerateFilter
            {
                get { return this.Attribute.AutoGenerateFilter; }
                set { this.Attribute.AutoGenerateFilter = value; }
            }
    
            public int Order
            {
                get { return this.Attribute.Order; }
                set { this.Attribute.Order = value; }
            }
    
            public string GetShortName()
            {
                return this.Attribute.GetShortName();
            }
               
            public string GetName()
            {
                return this.Attribute.GetName();
            }
    
            public string GetDescription()
            {
                return this.Attribute.GetDescription();
            }
    
            public string GetPrompt()
            {
                return this.Attribute.GetPrompt();
            }
    
            public string GetGroupName()
            {
                return this.Attribute.GetGroupName();
            }
    
            public bool? GetAutoGenerateField()
            {
                return this.Attribute.GetAutoGenerateField();
            }
    
            public bool? GetAutoGenerateFilter()
            {
                return this.Attribute.GetAutoGenerateFilter();
            }
              
            public int? GetOrder()
            {
                return this.Attribute.GetOrder();
             }  
         }
     }
