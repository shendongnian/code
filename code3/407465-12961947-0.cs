    using System;
    using System.Linq;
    using System.ComponentModel;
     
    namespace GUIKonfigurator
    {
        using System.Windows.Controls;
     
        public class ItemsControlTypeDescriptionProvider:TypeDescriptionProvider
        {
            private static readonly TypeDescriptionProvider defaultTypeProvider = TypeDescriptor.GetProvider(typeof(ItemsControl));
     
            public ItemsControlTypeDescriptionProvider(): base(defaultTypeProvider)
            {
            }
     
            public static void Register()
            {
                TypeDescriptor.AddProvider(new ItemsControlTypeDescriptionProvider(), typeof(ItemsControl));
            }
     
            public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType,object instance)
            {
                ICustomTypeDescriptor defaultDescriptor = base.GetTypeDescriptor(objectType, instance);
                return instance == null ? defaultDescriptor: new ItemsControlCustomTypeDescriptor(defaultDescriptor);
            }
        }
     
        internal class ItemsControlCustomTypeDescriptor: CustomTypeDescriptor
        {
            public ItemsControlCustomTypeDescriptor(ICustomTypeDescriptor parent): base(parent)
            {
            }
     
            public override PropertyDescriptorCollection GetProperties()
            {
                PropertyDescriptorCollection pdc = new PropertyDescriptorCollection(base.GetProperties().Cast<PropertyDescriptor>().ToArray());
                return ConvertPropertys(pdc);
            }
     
            public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
            {
                PropertyDescriptorCollection pdc = new PropertyDescriptorCollection(base.GetProperties(attributes).Cast<PropertyDescriptor>().ToArray());
                return ConvertPropertys(pdc);
            }
     
            private PropertyDescriptorCollection ConvertPropertys(PropertyDescriptorCollection pdc)
            {
                PropertyDescriptor pd = pdc.Find("ItemsSource", false);
                if (pd != null)
                {
                    PropertyDescriptor pdNew = TypeDescriptor.CreateProperty(typeof(ItemsControl), pd, new Attribute[]
                                                                                                           {
                                                                                                               new DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible),
                                                                                                               new DefaultValueAttribute("")
                                                                                                           });
                    pdc.Add(pdNew);
                    pdc.Remove(pd);
                }
                return pdc;
            }
        }
    }
