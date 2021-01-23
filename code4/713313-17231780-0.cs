    /// <summary>
            /// Translate a text value to its setting type
            /// </summary>
            /// <param name="type">Type to convert to</param>
            /// <param name="value">string to cast</param>
            /// <returns></returns>
            private static object CastHelper(Type type, string value)
            {
                switch (type.Name)
                {
                    case "Int32":
                        return Convert.ToInt32(value);
    
                    case "Byte":
                        return Convert.ToByte(value);
    
                    case "Boolean":
                        return Convert.ToBoolean(value);
    
                    case "Color":
                        {
                            try
                            {
                                string[] rgb = value.Split(',');
                                return Color.FromArgb(Convert.ToInt32(rgb[0]), Convert.ToInt32(rgb[1]), Convert.ToInt32(rgb[2]));
                            }
                            catch (Exception)
                            {
                                return Color.FromName(value);
                            }
                            
                        }
                    case "Font":
                        return (new FontConverter().ConvertFromString(value));
    
                    default:
                        return value;
                }
            }
