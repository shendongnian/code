    /// <summary>
        /// This <see cref="Mixin"/> is used to "automatically" implement <see cref="INotifyPropertyChanged"/> to a target class.
        /// <para>It will also override <c>ToString()</c> to show it's possible.</para>
        /// </summary>
        /// <example>This example adds <see cref="INotifyPropertyChanged"/> to <see cref="INPCTester"/> 
        /// <code>
        /// [ImplementsINPC]
        /// public class INPCTester
        /// {
        ///     private string m_Name;
        ///     public string Name
        ///     {
        ///         get { return m_Name; }
        ///         set
        ///         {
        ///             if (m_Name != value)
        ///             {
        ///                 m_Name = value;
        ///                 ((ICustomINPC)this).RaisePropertyChanged("Name");
        ///             }
        ///         }
        ///     }
        /// }
        /// 
        /// class Program
        /// {
        ///     static void Main(string[] args)
        ///     {
        ///         INPCImplementation();
        ///     }
        ///     
        ///     static void INPCImplementation()
        ///     {
        ///         Console.WriteLine("INPC implementation and usage");
        ///
        ///         var inpc = ObjectFactory.Create{INPCTester}(ParamList.Empty);
        ///
        ///         Console.WriteLine("The resulting object is castable as INPC: " + (inpc is INotifyPropertyChanged));
        ///
        ///         ((INotifyPropertyChanged)inpc).PropertyChanged += inpc_PropertyChanged;
        ///
        ///         inpc.Name = "New name!";
        ///         Console.WriteLine(inpc.ToString());
        ///         ((INotifyPropertyChanged)inpc).PropertyChanged -= inpc_PropertyChanged;
        ///         Console.WriteLine();
        ///     }
        /// }
        /// 
        /// //Outputs: 
        /// //
        /// //INPC implementation and usage
        /// //The resulting object is castable as INPC: True
        /// //Hello, world! Property's name: Name
        /// //Modified tostring!
        /// </code>
        /// </example>    
        /// <remarks>
        /// The <see cref="ImplementsINPCAttribute"/> is syntactic sugar for 
        /// <para>   <c>[Uses(typeof(INotifyPropertyChangedMixin))]</c> on top of the target class</para>
        /// <para>Which is equivalent to: </para>
        /// <para>   <c>[assembly: Mix(typeof(INPCTester), typeof(INotifyPropertyChangedMixin))]</c> outside the namespace.</para>
        /// <para>or <c>[Extends(typeof(INPCTester))]</c> on top of the mixin class</para>
        /// </remarks>
        public class INotifyPropertyChangedMixin : Mixin<object>, ICustomINPC
        {
            public event PropertyChangedEventHandler PropertyChanged;
            
            /// <inheritdoc />
            public void RaisePropertyChanged(string prop)
            {
                 PropertyChangedEventHandler handler = this.PropertyChanged;
                 if (handler != null)
                 {
                     handler(this, new PropertyChangedEventArgs(prop));
                 }
            }
    
            /// <inheritdoc />
            [OverrideTarget]
            public new string ToString()
            {
                return "Modified tostring!";
            }
        }
    
        public class ImplementsINPCAttribute : UsesAttribute 
        {
            public ImplementsINPCAttribute()
                : base(typeof(INotifyPropertyChangedMixin))
            {
                
            }
        }
