        /// <summary>
        /// Gets the value of the Property from the object.
        /// </summary>
        /// <param name="target">The object to get the Property value from.</param>
        /// <returns>
        /// The value of the Property for the target.
        /// </returns>
        public object Get(object target)
        {
            
            if (target is IMultilingualContentInfo)
            {
                try
                {
                    IMultilingualContentInfo multiLingualTarget = (IMultilingualContentInfo)target;
                    string s = (string)property.GetValue(target, new object[0]);
                    if (!string.IsNullOrWhiteSpace(s))
                    {
                        MultilingualLuceneTextContent mlText = new MultilingualLuceneTextContent();
                        mlText.Culture = multiLingualTarget.CultureInfo.GetCultureCode();
                        s = mlText.GetTextIncCulture();
                        
                    }
                    return s;
                }
                catch (Exception e)
                {
                    throw new PropertyAccessException(e, "Exception occurred", false, clazz, propertyName);
                }
            }
            else
            {
                throw new InvalidOperationException("Multilingual Getter is only available on IMultilingualContentInfo objects");
            }
            
        }
