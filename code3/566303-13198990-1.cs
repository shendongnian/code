    namespace Microsoft.Xna.Framework
    {
    #if WINDOWS
        public class Point3Converter: System.ComponentModel.ExpandableObjectConverter
        {
            public override bool CanConvertFrom( System.ComponentModel.ITypeDescriptorContext context, Type sourceType )
            {
                return sourceType == typeof( string );
            }
    
            public override object ConvertFrom( System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value )
            {
                try
                {
                    string[] tokens = (( string ) value).Split( ';' );
                    return new Point3( int.Parse( tokens[0] ), int.Parse( tokens[1] ), int.Parse( tokens[2] ) );
                }
                catch
                {
                    return context.PropertyDescriptor.GetValue( context.Instance );
                }
            }
    
            public override object ConvertTo( System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType )
            {
                Point3 p = ( Point3 ) value;
                return p.X +";"+ p.Y+";" + p.Z;
            }
        }
    
        [System.ComponentModel.TypeConverter( typeof( Point3Converter ) )]
    #endif
        public struct Point3
        {
            public int X,Y,Z;
    
            public static readonly Point3 UnitX = new Point3( 1, 0, 0 );
            public static readonly Point3 UnitY = new Point3( 0, 1, 0 );
            public static readonly Point3 UnitZ = new Point3( 0, 0, 1 );
    
            public Point3( int X, int Y, int Z )
            {
                this.X = X;
                this.Y = Y;
                this.Z = Z;
            }
    
            public static Vector3 operator +( Point3 A, Vector3 B )
            {
                return new Vector3( A.X + B.X, A.Y + B.Y, A.Z + B.Z );
            }
    
            public static Point3 operator +( Point3 A, Point3 B )
            {
                return new Point3( A.X + B.X, A.Y + B.Y, A.Z + B.Z );
            }
    
            public static Point3 operator -( Point3 A, Point3 B )
            {
                return new Point3( A.X - B.X, A.Y - B.Y, A.Z - B.Z );
            }
    
            public static Point3 operator -( Point3 A )
            {
                return new Point3( -A.X, -A.Y, -A.Z );
            }
    
    
            public override string ToString( )
            {
                return X+";"+Y+";"+Z;
            }
        }  
    }
