        public static bool IsCLRType(this Type type)
        {
            var definedCLRTypes = new List<Type>(){
                    typeof(System.Byte),
                    typeof(System.SByte),
                    typeof(System.Int16),
                    typeof(System.UInt16),
                    typeof(System.Int32),
                    typeof(System.UInt32),
                    typeof(System.Int64),
                    typeof(System.UInt64),
                    typeof(System.Single),
                    typeof(System.Double),
                    typeof(System.Decimal),
                    typeof(System.Guid),
                    typeof(System.Type),
                    typeof(System.Boolean),
                    typeof(System.String),
                    /* etc */
                };
            return definedCLRTypes.Contains(type);
        }
