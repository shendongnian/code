        public string BuildFilterExpression<T>()
        {
            var type = typeof(T);
            var exp = string.Empty;
            foreach (Filter filter in this)
            {
                var typeName = filter.DataType.ToLower();
                // Skip if no values
                if (!filter.Values.Any())
                    continue;
                switch (typeName)
                {
                    case "string":
                        // html decode string and escape single quotes
                        var stringVal = System.Web.HttpUtility.HtmlDecode(filter.Values[0]);
                        stringVal = stringVal.Replace("'", "''");
                        if (filter.Operator == Enums.FilterOperator.CONTAINS)
                            exp += string.Format("{0}.Trim().ToLower().Contains(\"{1}\")", filter.Attribute, stringVal.Trim().ToLower());
                        
                        else if (filter.Operator == Enums.FilterOperator.DOES_NOT_EQUAL)
                            exp += string.Format("!{0}.ToLower().Equals(\"{1}\")", filter.Attribute, stringVal.ToLower());
                        
                        else if (filter.Operator == Enums.FilterOperator.DOES_NOT_CONTAIN)
                            exp += string.Format("!{0}.Trim().ToLower().Contains(\"{1}\")", filter.Attribute, stringVal.Trim().ToLower());
                        
                        else if (filter.Operator == Enums.FilterOperator.ENDS_WITH)
                            exp += string.Format("{0}.Trim().ToLower().EndsWith(\"{1}\")", filter.Attribute, stringVal.Trim().ToLower());
                        else if (filter.Operator == Enums.FilterOperator.EQUALS)
                            exp += string.Format("{0}.ToLower().Equals(\"{1}\")", filter.Attribute, stringVal.ToLower());
                        else if (filter.Operator == Enums.FilterOperator.STARTS_WITH)
                            exp += string.Format("{0}.Trim().ToLower().StartsWith(\"{1}\")", filter.Attribute, stringVal.Trim().ToLower());
                        
                        break;
                    //case "select": -- for dropdowns
                    //case "datetime": -- for dates, etc. etc.
                // add spaces around expression
                exp = string.Format(" {0} ", exp);
                // add and/or to expression
                if (this.IndexOf(filter) != this.Count() - 1)
                    exp += string.Format(" {0} ", ExpressionType.ToLower() == "and" ? "&&" : "||");
            }
            return exp;
        }
