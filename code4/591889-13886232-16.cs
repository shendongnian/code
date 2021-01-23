    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    
    namespace WpfApplication
    {
        public class DataRecordCollection<T> : ObservableCollection<T>, ITypedList where T : DataRecord
        {
            private readonly PropertyDescriptorCollection properties;
    
            public DataRecordCollection(params DataProperty[] properties)
            {
                this.properties = new PropertyDescriptorCollection(properties);
            }
    
            protected override void InsertItem(int index, T item)
            {
                item.container = this;
                base.InsertItem(index, item);
            }
    
            PropertyDescriptorCollection ITypedList.GetItemProperties(PropertyDescriptor[] listAccessors)
            {
                return this.properties;
            }
    
            string ITypedList.GetListName(PropertyDescriptor[] listAccessors)
            {
                throw new NotImplementedException();
            }
        }
    }
