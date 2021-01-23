    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Shapes;
    namespace SO_AttachmentProperty
    {
        public sealed class EllipseAttachments
        {
            #region Field1
            public static int GetField1(DependencyObject obj)
            {
                return (int)obj.GetValue(Field1Property);
            }
    
            public static void SetField1(DependencyObject obj, int value)
            {
                obj.SetValue(Field1Property, value);
            }
    
            // Using a DependencyProperty as the backing store for Field1.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty Field1Property =
                DependencyProperty.RegisterAttached("Field1", typeof(int), typeof(Ellipse), new UIPropertyMetadata(0));
            #endregion
    
            #region Field2
            public static int GetField2(DependencyObject obj)
            {
                return (int)obj.GetValue(Field2Property);
            }
    
            public static void SetField2(DependencyObject obj, int value)
            {
                obj.SetValue(Field2Property, value);
            }
    
            // Using a DependencyProperty as the backing store for Field2.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty Field2Property =
                DependencyProperty.RegisterAttached("Field2", typeof(int), typeof(Ellipse), new UIPropertyMetadata(0));
            #endregion
        }
    }
