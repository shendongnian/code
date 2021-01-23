    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Interactivity;
    using System.Windows.Media.Animation;
    namespace TriggerTest
    {
        /// <summary>
        /// InteractiveTrigger is a trigger that can be used as the System.Windows.Trigger but in the System.Windows.Interactivity.
        /// <para>
        /// Note: There is no `EnterActions` nor `ExitActions` in this class. The `CommonActions` can be used instead of `EnterActions`.
        /// Also, the `Actions` property which is of type System.Windows.Interactivity.TriggerAction can be used.
        /// </para>
        /// <para> </para>
        /// <para>
        /// There is only one kind of triggers (i.e. EventTrigger) in the System.Windows.Interactivity. So you can use the following triggers in this namespace:
        /// <para>1- InteractiveTrigger : Trigger</para>
        /// <para>2- InteractiveMultiTrigger : MultiTrigger</para>
        /// <para>3- InteractiveDataTrigger : DataTrigger</para>
        /// <para>4- InteractiveMultiDataTrigger : MultiDataTrigger</para>
        /// </para>
        /// </summary>
        public class InteractiveTrigger : TriggerBase<FrameworkElement>
        {
            #region ___________________________________________________________________________________  Properties
            #region ________________________________________  Value
            /// <summary>
            /// [Wrapper property for ValueProperty]
            /// <para>
            /// Gets or sets the value to be compared with the property value of the element. The comparison is a reference equality check.
            /// </para>
            /// </summary>
            public object Value
            {
                get { return (object)GetValue(ValueProperty); }
                set { SetValue(ValueProperty, value); }
            }
            public static readonly DependencyProperty ValueProperty =
                DependencyProperty.Register("Value",
                                            typeof(object),
                                            typeof(InteractiveTrigger),
                                            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, OnValuePropertyChanged));
            private static void OnValuePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
            {
                InteractiveTrigger instance = sender as InteractiveTrigger;
                if (instance != null)
                {
                    if (instance.CanFire)
                        instance.Fire();
                }
            }
            #endregion
            /// <summary>
            /// Gets or sets the name of the object with the property that causes the associated setters to be applied.
            /// </summary>
            public string SourceName
            {
                get;
                set;
            }
            /// <summary>
            /// Gets or sets the property that returns the value that is compared with this trigger.Value property. The comparison is a reference equality check.
            /// </summary>
            public DependencyProperty Property
            {
                get;
                set;
            }
            /// <summary>
            /// Gets or sets a collection of System.Windows.Setter objects, which describe the property values to apply when the trigger object becomes active.
            /// </summary>
            public List<Setter> Setters
            {
                get;
                set;
            }
            /// <summary>
            /// Gets or sets the collection of System.Windows.TriggerAction objects to apply when this trigger object becomes active.
            /// </summary>
            public List<System.Windows.TriggerAction> CommonActions
            {
                get;
                set;
            }
            /// <summary>
            /// Gets a value indicating whether this trigger can be active to apply setters and actions.
            /// </summary>
            private bool CanFire
            {
                get
                {
                    if (this.AssociatedObject == null)
                    {
                        return false;
                    }
                    else
                    {
                        object associatedValue;
                        if (string.IsNullOrEmpty(SourceName))
                            associatedValue = this.AssociatedObject.GetValue(Property);
                        else
                            associatedValue = (this.AssociatedObject.FindName(SourceName) as DependencyObject).GetValue(Property);
                        TypeConverter typeConverter = TypeDescriptor.GetConverter(Property.PropertyType);
                        object realValue = typeConverter.ConvertFromString(Value.ToString());
                        return associatedValue.Equals(realValue);
                    }
                }
            }
            #endregion
            #region ___________________________________________________________________________________  Methods
            /// <summary>
            /// Fires (activates) current trigger by setting setter values and invoking all actions.
            /// </summary>
            private void Fire()
            {
                //
                // Setting setters values to their associated properties..
                //
                foreach (Setter setter in Setters)
                {
                    if (string.IsNullOrEmpty(setter.TargetName))
                        this.AssociatedObject.SetValue(setter.Property, setter.Value);
                    else
                        (this.AssociatedObject.FindName(setter.TargetName) as DependencyObject).SetValue(setter.Property, setter.Value);
                }
                //
                // Firing actions.. 
                //
                foreach (System.Windows.TriggerAction action in CommonActions)
                {
                    Type actionType = action.GetType();
                    if (actionType == typeof(BeginStoryboard))
                    {
                        (action as BeginStoryboard).Storyboard.Begin();
                    }
                    else
                        throw new NotImplementedException();
                    ///
                    /// Couldn't use this snippet:
                    ///
                    //TypeInfo info = actionType.GetTypeInfo();
                    //MethodInfo[] methodInfoes = info.DeclaredMethods.ToArray();
                    //actionType.InvokeMember("Invoke",
                    //                        BindingFlags.InvokeMethod,
                    //                        null,
                    //                        action,
                    //                        new object[] { this.Target });
                }
                this.InvokeActions(null);
            }
            #endregion
            #region ___________________________________________________________________________________  Events
            public InteractiveTrigger()
            {
                Setters = new List<Setter>();
                CommonActions = new List<System.Windows.TriggerAction>();
            }
            protected override void OnAttached()
            {
                base.OnAttached();
                if (Property != null)
                {
                    object propertyAssociatedObject;
                    if (string.IsNullOrEmpty(SourceName))
                        propertyAssociatedObject = this.AssociatedObject;
                    else
                        propertyAssociatedObject = this.AssociatedObject.FindName(SourceName);
                    //
                    // Adding a property changed listener to the property associated-object..
                    //
                    DependencyPropertyDescriptor dpDescriptor = DependencyPropertyDescriptor.FromProperty(Property, propertyAssociatedObject.GetType());
                    dpDescriptor.AddValueChanged(propertyAssociatedObject, PropertyListener_ValueChanged);
                }
            }
            protected override void OnDetaching()
            {
                base.OnDetaching();
                if (Property != null)
                {
                    object propertyAssociatedObject;
                    if (string.IsNullOrEmpty(SourceName))
                        propertyAssociatedObject = this.AssociatedObject;
                    else
                        propertyAssociatedObject = this.AssociatedObject.FindName(SourceName);
                    //
                    // Removing previously added property changed listener from the associated-object..
                    //
                    DependencyPropertyDescriptor dpDescriptor = DependencyPropertyDescriptor.FromProperty(Property, propertyAssociatedObject.GetType());
                    dpDescriptor.RemoveValueChanged(propertyAssociatedObject, PropertyListener_ValueChanged);
                }
            }
            private void PropertyListener_ValueChanged(object sender, EventArgs e)
            {
                if (CanFire)
                    Fire();
            }
            #endregion
        }
    }
