        public class QueryElement
        {
            public enum eOperator
            {
                AND, OR, EQ, NE, GT, GTE, LT, LTE      //etc.
            };
            public eOperator Operator { get; set; }
            public string Field { get; set; }
            public BsonValue Value { get; set; }
            public List<QueryElement> Children { get; set; }
            public IMongoQuery BuildQuery()
            {
                int i = 0;
                var qc = new IMongoQuery[(Children!=null)?Children.Count:0];
                if (Children != null)
                {
                    foreach (var child in Children)
                    {
                        qc[i++] = child.BuildQuery();
                    }
                }
                switch (Operator)
                {
                    // multiple element operators
                    case eOperator.AND:
                        return Query.And(qc);
                    case eOperator.OR:
                        return Query.And(qc);
                    // single element operators
                    case eOperator.EQ:
                        return Query.EQ(Field, Value);
                    case eOperator.NE:
                        return Query.NE(Field, Value);
                    case eOperator.GT:
                        return Query.GT(Field, Value);
                    case eOperator.GTE:
                        return Query.GTE(Field, Value);
                    case eOperator.LT:
                        return Query.LT(Field, Value);
                    case eOperator.LTE:
                        return Query.LTE(Field, Value);
                }
                return null;
            }
        }
