    using System;
    using System.ComponentModel;
    
    namespace WpfApplication
    {
        public class DataProperty : PropertyDescriptor
        {
            private readonly Type propertyType;
            private readonly bool isReadOnly;
            private readonly Attribute[] attributes;
    
            public DataProperty(string propertyName, Type propertyType, bool isReadOnly, params Attribute[] attributes)
                : base(propertyName, null)
            {
                this.propertyType = propertyType;
                this.isReadOnly = isReadOnly;
                this.attributes = attributes;
            }
    
            protected override Attribute[] AttributeArray
            {
                get { return this.attributes; }
                set { throw new NotImplementedException(); }
            }
    
            public override Type ComponentType
            {
                get { return typeof(DataRecord); }
            }
    
            public override Type PropertyType
            {
                get { return this.propertyType; }
            }
    
            public override bool IsReadOnly
            {
                get { return this.isReadOnly; }
            }
    
            public override object GetValue(object component)
            {
                return ((DataRecord)component)[this.Name];
            }
    
            public override void SetValue(object component, object value)
            {
                if (!this.isReadOnly)
                    ((DataRecord)component)[this.Name] = value;
            }
    
            #region Not implemented PropertyDescriptor Members
    
            public override bool CanResetValue(object component)
            {
                throw new NotImplementedException();
            }
    
            public override void ResetValue(object component)
            {
                throw new NotImplementedException();
            }
    
            public override bool ShouldSerializeValue(object component)
            {
                throw new NotImplementedException();
            }
    
            #endregion
        }
    }
