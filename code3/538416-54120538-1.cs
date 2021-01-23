        namespace EFExtensions
        {
            /// <summary>
            /// Specifies the default value for a property but allows a custom SQL statement to be provided as well. <see cref="MiniTuber.Database.Conventions.DefaultValueConvention"/>
            /// </summary>
            public class DefaultValueAttribute : System.ComponentModel.DefaultValueAttribute
            {
                /// <summary>
                /// Specifies the default value for a property but allows a custom SQL statement to be provided as well. <see cref="MiniTuber.Database.Conventions.DefaultValueConvention"/>
                /// </summary>
                public DefaultValueAttribute() : base("")
                {
                }
                /// <i
                /// <summary>
                /// Optional SQL to use to specify the default value.
                /// </summary>
                public string DefaultSql { get; set; }
                /// <summary>
                /// Initializes a new instance of the System.ComponentModel.DefaultValueAttribute
                /// class using a Unicode character.
                /// </summary>
                /// <param name="value">
                /// A Unicode character that is the default value.
                /// </param>
                public DefaultValueAttribute(char value) : base(value) { }
                /// <summary>
                /// Initializes a new instance of the System.ComponentModel.DefaultValueAttribute
                /// class using an 8-bit unsigned integer.
                /// </summary>
                /// <param name="value">
                /// An 8-bit unsigned integer that is the default value.
                /// </param>
                public DefaultValueAttribute(byte value) : base(value) { }
                /// <summary>
                /// Initializes a new instance of the System.ComponentModel.DefaultValueAttribute
                /// class using a 16-bit signed integer.
                /// </summary>
                /// <param name="value">
                /// A 16-bit signed integer that is the default value.
                /// </param>
                public DefaultValueAttribute(short value) : base(value) { }
                /// <summary>
                /// Initializes a new instance of the System.ComponentModel.DefaultValueAttribute
                /// class using a 32-bit signed integer.
                /// </summary>
                /// <param name="value">
                /// A 32-bit signed integer that is the default value.
                /// </param>
                public DefaultValueAttribute(int value) : base(value) { }
                /// <summary>
                /// Initializes a new instance of the System.ComponentModel.DefaultValueAttribute
                /// class using a 64-bit signed integer.
                /// </summary>
                /// <param name="value">
                /// A 64-bit signed integer that is the default value.
                /// </param>
                public DefaultValueAttribute(long value) : base(value) { }
                /// <summary>
                /// Initializes a new instance of the System.ComponentModel.DefaultValueAttribute
                /// class using a single-precision floating point number.
                /// </summary>
                /// <param name="value">
                /// A single-precision floating point number that is the default value.
                /// </param>
                public DefaultValueAttribute(float value) : base(value) { }
                /// <summary>
                /// Initializes a new instance of the System.ComponentModel.DefaultValueAttribute
                /// class using a double-precision floating point number.
                /// </summary>
                /// <param name="value">
                /// A double-precision floating point number that is the default value.
                /// </param>
                public DefaultValueAttribute(double value) : base(value) { }
                /// <summary>
                /// Initializes a new instance of the System.ComponentModel.DefaultValueAttribute
                /// class using a System.Boolean value.
                /// </summary>
                /// <param name="value">
                /// A System.Boolean that is the default value.
                /// </param>
                public DefaultValueAttribute(bool value) : base(value) { }
                /// <summary>
                /// Initializes a new instance of the System.ComponentModel.DefaultValueAttribute
                /// class using a System.String.
                /// </summary>
                /// <param name="value">
                /// A System.String that is the default value.
                /// </param>
                public DefaultValueAttribute(string value) : base(value) { }
                /// <summary>
                /// Initializes a new instance of the System.ComponentModel.DefaultValueAttribute
                /// class.
                /// </summary>
                /// <param name="value">
                /// An System.Object that represents the default value.
                /// </param>
                public DefaultValueAttribute(object value) : base(value) { }
                /// /// <inheritdoc/>
                /// Initializes a new instance of the System.ComponentModel.DefaultValueAttribute
                /// class, converting the specified value to the specified type, and using an invariant
                /// culture as the translation context.
                /// </summary>
                /// <param name="type">
                /// A System.Type that represents the type to convert the value to.
                /// </param>
                /// <param name="value">
                /// A System.String that can be converted to the type using the System.ComponentModel.TypeConverter
                /// for the type and the U.S. English culture.
                /// </param>
                public DefaultValueAttribute(Type type, string value) : base(value) { }
            }
        }
