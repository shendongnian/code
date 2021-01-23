        /// <param name="Fields">
        /// Format1: "Field1"
        /// Format2: "Nested1.Field1"
        /// Format3: "Field1:Field1Alias"
        /// </param>
        public static Expression<Func<T, TSelect>> DynamicSelectGenerator<T, TSelect>(params string[] Fields)
        {
            string[] EntityFields = Fields;
            if (Fields == null || Fields.Length == 0)
                // get Properties of the T
                EntityFields = typeof(T).GetProperties().Select(propertyInfo => propertyInfo.Name).ToArray();
            // input parameter "x"
            var xParameter = Expression.Parameter(typeof(T), "x");
            // new statement "new Data()"
            var xNew = Expression.New(typeof(TSelect));
            // create initializers
            var bindings = EntityFields
                .Select(x =>
                {
                    string[] xFieldAlias = x.Split(":");
                    string field = xFieldAlias[0];
                    string[] fieldSplit = field.Split(".");
                    if (fieldSplit.Length > 1)
                    {
                        // original value "x.Nested.Field1"
                        Expression exp = xParameter;
                        foreach (string item in fieldSplit)
                            exp = Expression.PropertyOrField(exp, item);
                        // property "Field1"
                        PropertyInfo member2 = null;
                        if (xFieldAlias.Length > 1)
                            member2 = typeof(TSelect).GetProperty(xFieldAlias[1]);
                        else
                            member2 = typeof(T).GetProperty(fieldSplit[fieldSplit.Length - 1]);
                        // set value "Field1 = x.Nested.Field1"
                        var res = Expression.Bind(member2, exp);
                        return res;
                    }
                    // property "Field1"
                    var mi = typeof(T).GetProperty(field);
                    var member = mi;
                    if (xFieldAlias.Length > 1)
                        member = typeof(TSelect).GetProperty(xFieldAlias[1]);
                    // original value "x.Field1"
                    var xOriginal = Expression.Property(xParameter, mi);
                    // set value "Field1 = x.Field1"
                    return Expression.Bind(member, xOriginal);
                }
            );
            // initialization "new Data { Field1 = x.Field1, Field2 = x.Field2 }"
            var xInit = Expression.MemberInit(xNew, bindings);
            // expression "x => new Data { Field1 = x.Field1, Field2 = x.Field2 }"
            var lambda = Expression.Lambda<Func<T, TSelect>>(xInit, xParameter);
            return lambda;
        }
